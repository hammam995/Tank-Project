using System;
using UnityEngine;

namespace Tank.Combat.Weapons.StrategyPattern
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private BaseWeapon startedWeapon;
        private IWeapon weaponCurrent;
        public event Action<IWeapon, IWeapon> WeaponChangeEvent; 
        private float shootTimer;

        private void Awake()
        {
            Change(startedWeapon as IWeapon);
        }

        public void Change(IWeapon weaponNew)
        {
            WeaponChangeEvent?.Invoke(weaponCurrent, weaponNew);
            weaponCurrent = weaponNew;
        }

        public void Shoot()
        {
            if (weaponCurrent == null) return;
            if (shootTimer > Time.time) return;
            
            shootTimer = Time.time + weaponCurrent.GetShootDelay();
            weaponCurrent.Shoot();
        }
    }
}
