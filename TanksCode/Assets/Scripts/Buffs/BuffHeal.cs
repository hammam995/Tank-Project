using MoonMonster.Codetest;
using UnityEngine;

namespace Buffs
{
    public class BuffHeal : Buff
    {
        [SerializeField] private float amount;
        
        protected override void Use()
        {
            PlayerTank.GetComponent<TankHealth>().Change(-amount);
        }
    }
}
