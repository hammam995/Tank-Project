using UnityEngine;

namespace Tank.Combat.Shells
{
    public class Grenade : MonoBehaviour
    {
        public float throwForce = 10f;
        public float gravity = 9.8f;
        public float upwardForce = 5f;
        
        private float elapsedTime;
        private Vector3 initialPosition;
        private Vector3 initialVelocity;
        
        private void OnEnable()
        {
            elapsedTime = 0f;
            initialPosition = transform.position;
            initialVelocity = transform.forward * throwForce + transform.up * upwardForce;;
        }

        private void FixedUpdate()
        {
            elapsedTime += Time.deltaTime;
            var yOffset = -0.5f * gravity * elapsedTime * elapsedTime;
            var gravityOffset = Vector3.up * yOffset;

            transform.position = initialPosition + initialVelocity * elapsedTime + gravityOffset;
        }
    }
}
