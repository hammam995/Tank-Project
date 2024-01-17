using UnityEngine;

namespace Tank.Combat.Weapons.Turret
{
    public class TurretRotatorTarget : TurretRotator
    {
        public Transform Target;
        [SerializeField] private float speed;
        
        private void Update()
        {
            if (Target == null) return;
  
            var dir = Target.position - Turret.position;
            dir.y = 0;
            dir.Normalize();
            
            var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
            Turret.rotation = Quaternion.Lerp(Turret.rotation, Quaternion.AngleAxis(angle, Vector3.down), speed * Time.fixedDeltaTime);
        }

        public void SetTarget(Transform target)
        {
            Target = target;
        }
    }
}
