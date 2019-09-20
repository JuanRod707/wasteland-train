using System.Collections;
using FootCombat.Scenario;
using UnityEngine;

namespace Assets.Scripts.FootCombat.Weapons
{
    public class HitscanWeapon : MonoBehaviour
    {
        const float InaccuracyFactor = 5f;

        public HitscanWeaponStats Stats;
        public ParticleSystem ShotLine;
        public ParticleSystem MuzzleFlash;

        public AudioSource FireSfx;

        bool isReady;

        void Start()
        {
            isReady = true;
        }

        public void AimAt(Vector3 target) => transform.LookAt(target);

        public void Fire()
        {
            if (isReady)
            {
                var aimPoint = CalculateAimPoint();
                isReady = false;
                var bulletHit = CalculateBulletHit(aimPoint);
                
                if(bulletHit.collider!= null)
                    FireBullet(bulletHit);
                
                DisplayShotLine(bulletHit.collider!= null ? bulletHit.point : aimPoint);
                StartCoroutine(WaitForCycle());
                MuzzleFlash.Emit(1);
                FireSfx.Play();
            }
        }

        RaycastHit CalculateBulletHit(Vector3 aimPoint)
        {
            RaycastHit hit;
            Physics.Raycast(ShotLine.transform.position, aimPoint, out hit);
            return hit;
        }
        
        void FireBullet(RaycastHit hit)
        {
            var surface = hit.collider.GetComponent<ImpactSurface>();
            if (surface != null)
            {
                surface.Hit(hit.point, transform.position);
            }
        }

        Vector3 CalculateAimPoint()
        {
            var inaccuracyPoint = Random.insideUnitSphere * InaccuracyFactor * Stats.Inaccuracy;
            return inaccuracyPoint + (transform.position + (transform.forward * Stats.Range));
        }

        void DisplayShotLine(Vector3 point)
        {
            ShotLine.transform.LookAt(point);
            ShotLine.Emit(1);
        }

        IEnumerator WaitForCycle()
        {
            yield return new WaitForSeconds(Stats.FireRate);
            isReady = true;
        }
    }
}
