using System;
using System.Collections.Generic;
using MoonMonster.Codetest;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Buffs
{
    public class SpawnerBuff : MonoBehaviour
    {
        [SerializeField] private List<Buff> possibleBuffs;
        [SerializeField] private float chanceToSpawn;
        [SerializeField] private TankHealth tankHealth;
        
        private void Awake()
        {
            tankHealth.DeathEvent += OnDeath;
        }

        private void OnDestroy()
        {
            tankHealth.DeathEvent -= OnDeath;
        }

        private void OnDeath()
        {
            if (Random.value > chanceToSpawn) return;
            var buff = possibleBuffs[Random.Range(0, possibleBuffs.Count)];
            Instantiate(buff.gameObject, transform.position, transform.rotation);
        }
    }
}
