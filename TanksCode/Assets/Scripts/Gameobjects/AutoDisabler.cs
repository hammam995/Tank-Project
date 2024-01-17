using UnityEngine;

namespace Gameobjects
{
    public class AutoDisabler : MonoBehaviour
    {
        [SerializeField] private float delay;

        private void OnEnable()
        {
            CancelInvoke(nameof(Disable));
            Invoke(nameof(Disable), delay);
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
