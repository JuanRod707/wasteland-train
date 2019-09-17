using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform TargetTransform;
    public float Speed;

    public void MoveFromVector(Vector2 vector)
    {
        TargetTransform.Translate(new Vector3(vector.x, 0f, vector.y) * Speed);
    }
}