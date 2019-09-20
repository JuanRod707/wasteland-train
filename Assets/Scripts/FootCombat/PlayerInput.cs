using Assets.Scripts.FootCombat.Entities;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Character Character;
    public float AimYOffset;

    void Update()
    {
        var movementVector = GetMovementVector();
        var aimingPoint = GetMouseAim();

        Character.Movement.MoveFromVector(movementVector);
        Character.View.LookAt(aimingPoint);
        Character.Weapon.AimAt(aimingPoint);

        if(Input.GetMouseButton(0))
            Character.Weapon.Fire();

        if (Input.GetKeyDown(KeyCode.Space))
            Character.Movement.Dash();
    }

    Vector3 GetMouseAim()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("AimFloor")))
        {
            var hitPoint = hit.point;
            hitPoint.y = AimYOffset;
            return hitPoint;
        }

        return Vector3.zero;
    }

    Vector2 GetMovementVector()
    {
        var result = new Vector2();

        if (Input.GetKey(KeyCode.W))
            result.y = 1;
        else if (Input.GetKey(KeyCode.S))
            result.y = -1;

        if (Input.GetKey(KeyCode.D))
            result.x = 1;
        else if (Input.GetKey(KeyCode.A))
            result.x = -1;

        return result;
    }
}
