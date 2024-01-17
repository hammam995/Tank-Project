using MoonMonster.Codetest;

namespace Buffs
{
    public class BuffShield : Buff
    {
        private static Buff current;
        
        protected override void Use()
        {
            current = this;
            PlayerTank.GetComponent<TankHealth>().AddImmunity();
            SetShieldEffect(true);
        }
        
        private void OnDestroy()
        {
            if (this != current) return;
            PlayerTank.GetComponent<TankHealth>().RemoveImmunity();
            SetShieldEffect(false);
        }

        private void SetShieldEffect(bool isActive)
        {
            PlayerTank.transform.Find("Shield").gameObject.SetActive(isActive);
        }
    }
}
