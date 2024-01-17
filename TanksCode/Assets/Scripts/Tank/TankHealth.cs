using System;
using UnityEngine;
using UnityEngine.UI;

namespace MoonMonster.Codetest
{
    public class TankHealth : MonoBehaviour
    {
        public float StartingHealth = 100f;               
        public Slider Slider;                             
        public Image FillImage;                           
        public Color FullHealthColor = Color.green;       
        public Color ZeroHealthColor = Color.red;         
        public GameObject ExplosionPrefab;
        public bool IsImmune;
        
        public event Action DeathEvent;
        public event Action<float> ChangeEvent;

        private AudioSource _explosionAudio;               
        private ParticleSystem _explosionParticles;        
        private float _currentHealth;                      
        private bool _dead;                                


        private void Awake ()
        {
            _explosionParticles = Instantiate (ExplosionPrefab).GetComponent<ParticleSystem> ();

            _explosionAudio = _explosionParticles.GetComponent<AudioSource> ();

            _explosionParticles.gameObject.SetActive (false);
        }


        private void OnEnable()
        {
            _currentHealth = StartingHealth;
            _dead = false;

            SetHealthUI();
        }


        public void Change (float amount)
        {
            if (amount > 0 && IsImmune) return;
            
            _currentHealth -= amount;

            SetHealthUI ();

            ChangeEvent?.Invoke(amount);
            
            if (_currentHealth <= 0f && !_dead)
            {
                OnDeath ();
            }
        }

        public void AddImmunity()
        {
            IsImmune = true;
        }

        public void RemoveImmunity()
        {
            IsImmune = false;
        }


        private void SetHealthUI ()
        {
            Slider.value = _currentHealth;

            FillImage.color = Color.Lerp (ZeroHealthColor, FullHealthColor, _currentHealth / StartingHealth);
        }


        private void OnDeath ()
        {
            _dead = true;

            _explosionParticles.transform.position = transform.position;
            _explosionParticles.gameObject.SetActive (true);

            _explosionParticles.Play ();

            _explosionAudio.Play();

            gameObject.SetActive (false);
            
            DeathEvent?.Invoke();
        }
    }
}