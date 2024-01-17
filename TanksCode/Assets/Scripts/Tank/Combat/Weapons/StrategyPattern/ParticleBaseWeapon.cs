using UnityEngine;
using UnityEngine.Events;

namespace Tank.Combat.Weapons.StrategyPattern
{
    public class ParticleBaseWeapon : BaseWeapon, IWeapon
    {
        [SerializeField] private UnityEvent actionStart;
        [SerializeField] private UnityEvent actionStop;
        [SerializeField] private float delayToStop;

        private void ShootStop()
        {
            actionStop.Invoke();
        }

        public void Shoot()
        {
            actionStart.Invoke();
            CancelInvoke(nameof(ShootStop));
            Invoke(nameof(ShootStop), delayToStop);
        }
        
        public float GetShootDelay()
        {
            return ShootTimeDelay;
        }
    }
}
