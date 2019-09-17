using Assets.Scripts.FootCombat.Weapons;
using UnityEngine;

namespace Assets.Scripts.FootCombat.Entities
{
    public class Character : MonoBehaviour
    {
        public Transform WeaponSpot;
        public CharacterMovement Movement;
        public CharacterView View;

        [HideInInspector]
        public HitscanWeapon Weapon;

        void Start()
        {
            SwitchWeapon();
        }

        void SwitchWeapon() => Weapon = WeaponSpot.GetComponentInChildren<HitscanWeapon>();

        void Update()
        {
            WeaponSpot.position = View.WeaponSpot.position;
        }
    }
}
