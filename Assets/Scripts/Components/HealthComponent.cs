using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _minHP;
        [SerializeField] private int _maxHP;
        [SerializeField] private int _curentHP;
        [SerializeField] private UnityEvent OnTakeDamage;
        [SerializeField] private UnityEvent OnDie;

        public void ApplyDamage(int damage)
        {
            _curentHP -= damage;
            OnTakeDamage?.Invoke();

            if (_curentHP <= _minHP)
            {
                OnDie?.Invoke();
            }
        }

        public void ApplyHealing(int heal) 
        {
            if (_curentHP + heal >= _maxHP)
            {
                _curentHP = _maxHP;
            }
            else
            {
                _curentHP += heal;
            }
        }
    }
}
