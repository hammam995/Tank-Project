namespace Tank.Combat.Weapons.StrategyPattern
{
    public interface IWeapon
    {
        void Shoot();
        
        float GetShootDelay();
    }
}
