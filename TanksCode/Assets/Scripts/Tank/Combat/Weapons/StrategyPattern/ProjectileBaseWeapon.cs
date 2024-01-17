using UnityEngine;

namespace Tank.Combat.Weapons.StrategyPattern
{
    public class ProjectileBaseWeapon : BaseWeapon, IWeapon
    {
        public void Shoot()
        {
            GetComponent<WeaponShellSpawner>().Spawn();
        }

        public float GetShootDelay()
        {
            return ShootTimeDelay;
        }
    }
}