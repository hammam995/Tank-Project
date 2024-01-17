using System.Linq;
using PathCreation;
using UnityEngine;

namespace AI
{
    public class AITankMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform body;
        private float distanceTravelled;
        private PathCreator path;

        private void Awake()
        {
            path = FindObjectsOfType<PathCreator>().OrderBy(a => (a.transform.position - transform.position).sqrMagnitude).First();
            var pos = path.path.GetPointAtDistance(0);
            pos.y = rb.position.y;
            rb.MovePosition(pos);
        }

        private void FixedUpdate()
        {
            distanceTravelled += speed * Time.fixedDeltaTime;
            
            var pos = path.path.GetPointAtDistance(distanceTravelled);
            pos.y = rb.position.y;
            rb.MovePosition(pos);
            
            var rotation = path.path.GetRotationAtDistance(distanceTravelled);
            var euler = rotation.eulerAngles;
            euler.x = euler.z = 0;
            transform.localEulerAngles = euler;
        }
    }
}
