using Tank.Combat.Weapons.StrategyPattern;
using UnityEngine;
using UnityEngine.Events;

namespace Tank.Combat.Weapons
{
    public class WeaponStateListener : MonoBehaviour
    {
        [SerializeField] private WeaponController weaponController;
        private IWeapon weapon;
        public UnityEvent OnAction, OffAction;

        private void Awake()
        {
            weapon = GetComponent<IWeapon>();
            weaponController.WeaponChangeEvent += OnWeaponChange;
        }

        private void OnDestroy()
        {
            weaponController.WeaponChangeEvent -= OnWeaponChange;
        }

        private void OnWeaponChange(IWeapon weaponCurrent, IWeapon weaponNew)
        {
            if (weaponNew == weapon) OnAction.Invoke();
            if (weaponNew != weapon) OffAction.Invoke();
        }
    }
}
