using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Hero
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        #region Input by class HeroInput
        //private HeroInput _input;

        //private void Awake()
        //{
        //    _input = new HeroInput();

        //    _input.HeroMap.Movement.performed += OnMovement;
        //    _input.HeroMap.Movement.canceled += OnMovement;

        //    _input.HeroMap.TellSomething.canceled += OnTellSomething;
        //}

        //private void OnEnable()
        //{
        //    _input.Enable();
        //}
        #endregion

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        public void OnTellSomething(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.TellSomething();
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.Interact();
            }
        }
    }

}


