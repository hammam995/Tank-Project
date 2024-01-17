using Tank.Combat.Weapons;
using Tank.Combat.Weapons.StrategyPattern;
using Tank.Combat.Weapons.Turret;
using UnityEngine;

namespace AI
{
    public class AIBattleController : MonoBehaviour
    {
        public float Distance;
        public float AggressionDistance = 15;
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private TurretRotatorTarget TurretRotatorTarget;
        public Transform Target { get; set; }

        private void Awake()
        {
            Target = GameObject.FindWithTag("Player").transform;
        }

        private void Update()
        {
            Distance = (transform.position - Target.position).magnitude;
            if (AggressionDistance < Distance)
            {
                TurretRotatorTarget.SetTarget(null);
                return;
            }
            TurretRotatorTarget.SetTarget(Target);
            weaponController.Shoot();
        }
    }
}