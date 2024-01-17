using MoonMonster.Codetest;
using UnityEngine;

namespace Tank.Combat.Weapons
{
    public class WeaponParticleDamage : MonoBehaviour
    {
        [SerializeField] private float damage;

        private void OnParticleCollision(GameObject other)
        {
            var health = other.GetComponent<TankHealth>();
            if (health)
            {
                health.Change(damage * Time.deltaTime);
            }
        }
    }
}
