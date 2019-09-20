using System.Collections;
using UnityEngine;

namespace FootCombat.Movement
{
    public class Dash : MonoBehaviour
    {
        public float Duration;
        public float Speed;

        Transform targetTransform;
        Vector3 dashDirection;

        public void Initialize(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
            enabled = false;
        }

        public void Do(Vector3 direction)
        {
            if (!enabled)
            {
                dashDirection = direction;
                StartCoroutine(WaitAndStop());
                enabled = true;
            }
        }

        void Update() => targetTransform.Translate(dashDirection * Speed);

        IEnumerator WaitAndStop()
        {
            yield return new WaitForSeconds(Duration);
            enabled = false;   
        }
    }
}