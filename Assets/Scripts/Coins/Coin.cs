using Assets.Scripts.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Coins
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _coinValue;
        [SerializeField] private ScoreComponent _score;

        public void AddScore()
        {
            _score.AddScore(_coinValue);
        }
    }
}