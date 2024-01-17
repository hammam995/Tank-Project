using UnityEngine;

namespace Tank
{
    public class TankMovementPlayer : MonoBehaviour
    {         
        public float Speed = 12f;                
        public float TurnSpeed = 180f;
        public float Factor = 1;
        public AudioSource MovementAudio;        
        public AudioClip EngineIdling;           
        public AudioClip EngineDriving;          
		public float PitchRange = 0.2f;          
        public GameObject TankBody;

        private Rigidbody _rigidbody;
        private float _verticalInputValue;        
        private float _horizontalInputValue;
        private float _originalPitch;
        private ParticleSystem[] _particleSystems;
        private Camera _camera;
        
        private void Awake ()
        {
            _rigidbody = GetComponent<Rigidbody> ();
            _camera = Camera.main;
        }

        public void AddSpeedFactor(float factor)
        {
            Factor = factor;
        }

        public void RemoveSpeedFactor()
        {
            Factor = 1;
        }

        private void OnEnable ()
        {
            _rigidbody.isKinematic = false;

            _verticalInputValue = 0f;
            _horizontalInputValue = 0f;

            _particleSystems = GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < _particleSystems.Length; ++i)
            {
                _particleSystems[i].Play();
            }
        }
        
        private void OnDisable ()
        {
            _rigidbody.isKinematic = true;

            for(int i = 0; i < _particleSystems.Length; ++i)
            {
                _particleSystems[i].Stop();
            }
        }
        
        private void Start ()
        {
            _originalPitch = MovementAudio.pitch;
        }
        
        private void Update ()
        {
            EngineAudio ();
        }
        
        public void SetMoveInput(float movement, float turn)
        {
            _verticalInputValue = movement;
            _horizontalInputValue = turn;
        }
        
        private void EngineAudio ()
        {
            if (Mathf.Abs (_verticalInputValue) < 0.1f && Mathf.Abs (_horizontalInputValue) < 0.1f)
            {
                if (MovementAudio.clip == EngineDriving)
                {
                    MovementAudio.clip = EngineIdling;
                    MovementAudio.pitch = Random.Range (_originalPitch - PitchRange, _originalPitch + PitchRange);
                    MovementAudio.Play ();
                }
            }
            else
            {
                if (MovementAudio.clip == EngineIdling)
                {
                    MovementAudio.clip = EngineDriving;
                    MovementAudio.pitch = Random.Range(_originalPitch - PitchRange, _originalPitch + PitchRange);
                    MovementAudio.Play();
                }
            }
        }
        
        private void FixedUpdate ()
        {
            Move ();
        }
        
        private void Move ()
        {
            if(_verticalInputValue == 0 && _horizontalInputValue == 0)
                return;
            
            var forward = _camera.transform.forward;
            var right = _camera.transform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();
            
            Vector3 movement = (_verticalInputValue * forward + _horizontalInputValue * right) * (Speed * Time.fixedDeltaTime * Factor);

            _rigidbody.MovePosition(_rigidbody.position + movement);
            
            var targetRotation = Quaternion.LookRotation(movement.normalized, Vector3.up);
            TankBody.transform.rotation = Quaternion.Slerp(TankBody.transform.rotation, targetRotation, TurnSpeed * Time.fixedDeltaTime);
        }
    }
}