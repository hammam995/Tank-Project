using UnityEngine;

namespace Tank.Combat.Weapons.Inputs
{
    public class WeaponChangerInputKey : MonoBehaviour
    {
        [SerializeField] private string changeButtonName;
        [SerializeField] private int index;
        [SerializeField] private WeaponChangerInputMouseScroll weaponChangerInputMouseScroll;
        private static int weapon;
        
        private void Update()
        {
            if (Input.GetButtonDown(changeButtonName))
            {
                weaponChangerInputMouseScroll.SetIndex(index);
            }
        }
    }
}
