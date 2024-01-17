using System.Collections.Generic;
using System.Linq;
using Tank.Combat.Weapons.StrategyPattern;
using UnityEngine;

namespace Tank.Combat.Weapons.Inputs
{
    public class WeaponChangerInputMouseScroll : MonoBehaviour
    {
        public int Index;
        [SerializeField] private WeaponController weaponController;
        private List<IWeapon> weaponList = new();

        private void Awake()
        {
            weaponList = GetComponentsInChildren<IWeapon>().ToList();
        }

        private void Update()
        {
            if (Input.mouseScrollDelta.y > 0) Index--;
            if (Input.mouseScrollDelta.y < 0) Index++;
            if (Index < 0) Index = weaponList.Count - 1;
            if (Index > weaponList.Count - 1) Index = 0;
            weaponController.Change(weaponList[Index]);
        }

        public void SetIndex(int index)
        {
            Index = index;
        }
    }
}
