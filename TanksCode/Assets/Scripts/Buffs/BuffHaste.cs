using MoonMonster.Codetest;
using Tank;

namespace Buffs
{
    public class BuffHaste : Buff
    {
        private static Buff current;
        
        protected override void Use()
        {
            current = this;
            PlayerTank.GetComponent<TankMovementPlayer>().AddSpeedFactor(2f);
            SetHasteEffect(true);
        }
        
        private void OnDestroy()
        {
            if (this != current) return;
            PlayerTank.GetComponent<TankMovementPlayer>().RemoveSpeedFactor();
            SetHasteEffect(false);
        }
        
        private void SetHasteEffect(bool isActive)
        {
            PlayerTank.transform.Find("Haste").gameObject.SetActive(isActive);
        }
    }
}
