using Tank.Combat.Weapons.StrategyPattern;
using Tank.Weapon;
using UnityEngine;

namespace Tank.Combat.Weapons.Inputs
{
    public class WeaponShooterInputKey : MonoBehaviour
    {
        [SerializeField] private string fireButtonName;
        [SerializeField] private WeaponController WeaponController;

        private void Update()
        {
            if (Input.GetButton(fireButtonName)) WeaponController.Shoot();
        }
    }
}
