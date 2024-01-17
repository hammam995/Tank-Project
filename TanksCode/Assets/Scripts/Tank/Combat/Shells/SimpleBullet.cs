using UnityEngine;

namespace Tank.Combat.Shells
{
    public class SimpleBullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private void Update()
        {
            transform.position = transform.position + transform.forward * (speed * Time.deltaTime);
        }
    }
}
