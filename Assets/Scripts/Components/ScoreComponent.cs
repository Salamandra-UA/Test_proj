using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class ScoreComponent : MonoBehaviour
    {
        private int _score;

        public void AddScore(int points)
        {
            _score += points;
        }

        public int GetScore() => _score;
    }
}