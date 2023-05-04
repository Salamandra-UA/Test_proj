using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int _damage;

        public void ApplayDamage(GameObject target)
        {
            if (target.TryGetComponent(out HealthComponent health))
            {
                health.ApplyDamage(_damage);
            }
        }
    }
}
