using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    [RequireComponent(typeof(Animator))]

    public class SwichComponent : MonoBehaviour
    {
        [SerializeField] private bool _isSwitched;
        [SerializeField] private string _animationKey;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Switch()
        {
            _isSwitched = !_isSwitched;
            _animator.SetBool(_animationKey, _isSwitched);
        }
    }
}
