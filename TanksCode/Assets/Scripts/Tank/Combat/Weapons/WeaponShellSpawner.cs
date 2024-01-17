using Patterns;
using UnityEngine;

namespace Tank.Combat.Weapons
{
    public class WeaponShellSpawner : MonoBehaviour
    {
        public GameObject Prefab;

        public void Spawn()
        {
            var obj = ObjectPool.Spawn(Prefab, transform.position, transform.eulerAngles);
            obj.SetActive(true);
            obj.layer = gameObject.layer;
        }
    }
}
