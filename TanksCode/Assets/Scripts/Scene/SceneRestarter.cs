using Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneRestarter : MonoBehaviour
    {
        public void Restart()
        {
            ObjectPool.Clear();
            SceneManager.LoadScene(0);
        }
        
        public void RestartWithDelay(float delay)
        {
            Invoke(nameof(Restart), delay);
        }
    }
}
