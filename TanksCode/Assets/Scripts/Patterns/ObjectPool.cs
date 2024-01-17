using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    public class ObjectPool : MonoBehaviour
    {
        private static Dictionary<GameObject, List<GameObject>> cache = new Dictionary<GameObject, List<GameObject>>();

        public static GameObject Spawn(GameObject prefab, Vector3 position, Vector3 euler)
        {
            var result = cache.ContainsKey(prefab);
            if (!result)
            {
                cache.Add(prefab, new List<GameObject>());
            }

            var list = cache[prefab];
            foreach (var obj in list)
            {
                if (obj.activeInHierarchy == false)
                {
                    obj.transform.position = position;
                    obj.transform.eulerAngles = euler;
                    return obj;
                }
            }

            var spawnedObj = Instantiate(prefab, position, Quaternion.Euler(euler));

            list.Add(spawnedObj);
            
            return spawnedObj;
        }

        public static void Clear()
        {
            cache.Clear();
        }
    }
}
