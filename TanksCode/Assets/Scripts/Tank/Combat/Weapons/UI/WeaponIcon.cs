using Tank.Combat.Weapons.StrategyPattern;
using UnityEngine;
using UnityEngine.UI;

namespace Tank.Combat.Weapons.UI
{
    public class WeaponIcon : MonoBehaviour
    {
        [SerializeField] private Sprite sprite;
        [SerializeField] private WeaponController weaponController;
        private IWeapon baseWeapon;
        private static Image weaponIconImage;
        
        private void Awake()
        {
            baseWeapon = GetComponent<IWeapon>();
            weaponController.WeaponChangeEvent += OnWeaponChange;
            if (weaponIconImage == null) weaponIconImage = GameObject.Find("WeaponIcon").GetComponent<Image>();
        }

        private void OnDestroy()
        {
            weaponController.WeaponChangeEvent -= OnWeaponChange;
        }

        private void OnWeaponChange(IWeapon weaponCurrent, IWeapon weaponNew)
        {
            if (weaponNew == baseWeapon) weaponIconImage.sprite = sprite;
        }
    }
}
