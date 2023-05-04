using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class AnimationComponent : MonoBehaviour
    {
        [SerializeField] private bool _loop;
        [SerializeField] private int _frameRate;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;

        private SpriteRenderer _spriteRenderer;
        private float _secondsPerFrame;
        private float _nextFrameTime;
        private int _currentSpriteIndex;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _secondsPerFrame = 1f / _frameRate;
            _nextFrameTime = Time.time + _secondsPerFrame;
            _currentSpriteIndex = 0;
        }

        private void Update()
        {
            if (_nextFrameTime > Time.time) return;

            if (_currentSpriteIndex >= _sprites.Length)
            {
                if (_loop)
                {
                    _currentSpriteIndex = 0;
                }
                else
                {
                    enabled = false;
                    _onComplete?.Invoke();
                    return;
                }
            }

            _spriteRenderer.sprite = _sprites[_currentSpriteIndex];
            _nextFrameTime += _secondsPerFrame;
            _currentSpriteIndex++;
        }
    }

}

