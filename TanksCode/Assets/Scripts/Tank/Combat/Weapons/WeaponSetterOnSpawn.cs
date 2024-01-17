using Tank.Combat.Weapons.Inputs;
using UnityEngine;

namespace Tank.Combat.Weapons
{
    public class WeaponSetterOnSpawn : MonoBehaviour
    {
        [SerializeField] private WeaponChangerInputMouseScroll weaponChangerInputMouseScroll;
        [SerializeField] private int index;
        
        public void OnEnable()
        {
            weaponChangerInputMouseScroll.SetIndex(index);
        }
    }
}
