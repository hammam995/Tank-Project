using MoonMonster.Codetest;
using Patterns;
using UnityEngine;

namespace Tank.Combat.Shells
{
    public class ShellExplosion : MonoBehaviour
    {
        public GameObject Explosion;
        public float MaxDamage = 100f;
        public float ExplosionForce = 1000f;
        public float ExplosionRadius = 5f;
        [SerializeField] private int playerMask, enemyMask;

        private void OnTriggerEnter(Collider other)
        {
            var targetLayer = gameObject.layer == playerMask ? enemyMask : playerMask;
            
            Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRigidbody)
                    continue;

                if (targetRigidbody.gameObject.layer != targetLayer) continue;
                
                targetRigidbody.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);

                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

                if (!targetHealth)
                    continue;

                float damage = CalculateDamage(targetRigidbody.position);

                targetHealth.Change(damage);
            }

            var obj = ObjectPool.Spawn(Explosion, transform.position, transform.eulerAngles);
            obj.SetActive(true);
            gameObject.SetActive(false);
        }


        private float CalculateDamage(Vector3 targetPosition)
        {
            Vector3 explosionToTarget = targetPosition - transform.position;

            float explosionDistance = explosionToTarget.magnitude;

            float relativeDistance = (ExplosionRadius - explosionDistance) / ExplosionRadius;

            float damage = relativeDistance * MaxDamage;

            damage = Mathf.Max(0f, damage);

            return damage;
        }
    }
}