using System.Collections;
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
                var aimPonit = CalculateAimPoint();
                isReady = false;
                DisplayShotLine(aimPonit);
                StartCoroutine(WaitForCycle());
                MuzzleFlash.Emit(1);
                FireSfx.Play();
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
