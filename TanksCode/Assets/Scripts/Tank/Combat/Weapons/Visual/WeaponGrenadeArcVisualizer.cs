using System;
using Tank.Combat.Shells;
using UnityEngine;

namespace Tank.Combat.Weapons
{
    public class WeaponGrenadeArcVisualizer : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        
        [SerializeField] private int arcResolution;
        [SerializeField] private float elapsedTime;
        [SerializeField] private Grenade grenade;
        [SerializeField] private Transform aimTransform;
        [SerializeField] private float groundY;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            if (lineRenderer == null)
            {
                lineRenderer = gameObject.AddComponent<LineRenderer>();
            }
            lineRenderer.positionCount = arcResolution;
        }
        
        private void FixedUpdate()
        {
            DrawTrajectory();
        }
        
        private void DrawTrajectory()
        {
            var initialPosition = transform.position;
            var initialVelocity = transform.forward * grenade.throwForce + transform.up * grenade.upwardForce;
            for (var i = 0; i < arcResolution; i++)
            {
                var time = i / (float)(arcResolution - 1) * elapsedTime;
                var yOffset = -0.5f * grenade.gravity * time * time;
                var gravityOffset = Vector3.up * yOffset;
                var point = initialPosition + initialVelocity * time + gravityOffset;
                lineRenderer.SetPosition(i, point);
                if (i == arcResolution - 1)
                {
                    point.y = groundY;
                    aimTransform.position = point;
                } 
            }
        }
    }
}
