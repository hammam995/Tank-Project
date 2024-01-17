using MoonMonster.Codetest;
using UnityEngine;

namespace Buffs
{
    public abstract class Buff : MonoBehaviour
    {
        protected static GameObject PlayerTank;
        [SerializeField] private float lifeTimeAfterGrab;
        [SerializeField] private ParticleSystem effectOnGrab;
        [SerializeField] private GameObject icon;

        private void Awake()
        {
            GameManager.RoundEndEvent += OnRoundEnd;
        }

        private void OnDestroy()
        {
            GameManager.RoundEndEvent -= OnRoundEnd;
        }

        private void OnRoundEnd()
        {
            if (this != null) Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!enabled) return;
            if (PlayerTank == null) PlayerTank = GameObject.FindWithTag("Player");
            Use();
            effectOnGrab.Play();
            enabled = false;
            icon.SetActive(false);
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, lifeTimeAfterGrab);
        }

        protected abstract void Use();
    }
}
