using UnityEngine;

namespace FootCombat.Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        public Transform TargetTransform;
        public Dash DashMove;
        public float Speed;

        Vector3 lastMoveVector;

        void Start()
        {
            DashMove.Initialize(TargetTransform);
        }
        
        public void MoveFromVector(Vector2 vector)
        {
            if (vector.magnitude > 0)
            {
                lastMoveVector = new Vector3(vector.x, 0f, vector.y);
                TargetTransform.Translate(lastMoveVector * Speed);
            }
        }

        public void Dash()
        {
            if(lastMoveVector.magnitude > 0)
                DashMove.Do(lastMoveVector.normalized);
        }
    }
}