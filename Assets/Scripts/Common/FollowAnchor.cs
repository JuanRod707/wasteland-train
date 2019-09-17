using UnityEngine;

namespace Assets.Scripts.Common
{
    public class FollowAnchor : MonoBehaviour
    {
        public float Stiffnes;

        Transform target;

        public void AnchorTo(Transform target) => this.target = target;
        

        void Update()
        {
            if (target != null)
                transform.position = Vector3.Lerp(transform.position, target.position, Stiffnes);
        }
    }
}
