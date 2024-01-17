using Tank.Combat.Weapons.Turret;
using UnityEngine;

namespace Tank.Weapon
{
    public class TurretRotatorMouse : TurretRotator
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            var mousePos = Input.mousePosition;
            var plane = new Plane(Vector3.up, Vector3.zero);
            var ray = _camera.ScreenPointToRay(mousePos);
            if (!plane.Raycast(ray, out var distance)) return;
            var targetPos = ray.GetPoint(distance);
            var dir = targetPos - Turret.position;
            dir.y = 0;
            dir.Normalize();
            var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
            Turret.rotation = Quaternion.AngleAxis(angle, Vector3.down);
        }
    }
}
