using System;

namespace Assets.Scripts.FootCombat.Weapons
{
    [Serializable]
    public class HitscanWeaponStats
    {
        public float Damage;
        public float Range;
        public float FireRate;
        public float AccuracyPctg;

        public float Inaccuracy => 1 - AccuracyPctg/100;
    }
}
