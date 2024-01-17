using System;
using DamageNumbersPro;
using MoonMonster.Codetest;
using UnityEngine;

namespace Visual
{
    public class HealthChangeEffectController : MonoBehaviour
    {
        [SerializeField] private TankHealth tankHealth;
        [SerializeField] private DamageNumber damageNumberMesh, healNumberMesh;
        
        private void Awake()
        {
            tankHealth.ChangeEvent += OnChange;
        }

        private void OnDestroy()
        {
            tankHealth.ChangeEvent -= OnChange;
        }

        private void OnChange(float amount)
        {
            if (amount == 0) return;
            var mesh = amount > 0 ? damageNumberMesh : healNumberMesh;
            var obj = mesh.Spawn(transform.position, Mathf.Abs(amount));
        }
    }
}
