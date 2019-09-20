using UnityEngine;

namespace FootCombat.Scenario
{
    public class ImpactSurface : MonoBehaviour
    {
        public ParticleSystem HitVfx;

        public void Hit(Vector3 hitPoint, Vector3 hitOrigin)
        {
            HitVfx.transform.position = hitPoint;
            HitVfx.transform.LookAt(hitOrigin);
            HitVfx.Play();
        }
    }
}