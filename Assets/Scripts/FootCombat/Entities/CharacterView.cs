using UnityEngine;

namespace Assets.Scripts.FootCombat.Entities
{
    public class CharacterView : MonoBehaviour
    {
        public Transform WeaponSpot;

        public void LookAt(Vector3 target)
        {
            transform.LookAt(target);
            NormalizeRotation();
        }

        void NormalizeRotation()
        {
            var normalizedEuler = new Vector3(0f, transform.eulerAngles.y, 0f);
            transform.eulerAngles = normalizedEuler;
        }

       
    }
}
