using Assets.Scripts.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _damageJumpSpeed;
        [SerializeField] private ColliderCheck _check;
        [SerializeField] private float _interactDistance;
        [SerializeField] private LayerMask _interactableLayer;

        #region Useless properties
        //[SerializeField] private LayerMask _groundLayer;
        //[SerializeField] private float _groundCheckRadius;
        //[SerializeField] private Vector3 _groundCheckPositionDelta;
        #endregion

        private Vector2 _direction;
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private ScoreComponent _scoreComponent;
        private readonly RaycastHit2D[] _hits = new RaycastHit2D[1];

        #region Flag for double jump
        //private bool _allowDoubleJump;
        #endregion

        private static readonly int _isGroundHash = Animator.StringToHash("is_ground");
        private static readonly int _isRunningHash = Animator.StringToHash("is_running");
        private static readonly int _isFallingHash = Animator.StringToHash("vertical_velocity");
        private static readonly int _hit = Animator.StringToHash("hit");

        public void SetDirection(Vector2 value)
        {
            _direction = value;
        }
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _scoreComponent = GetComponent<ScoreComponent>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            var newXVelocity = _direction.x * _speed;
            var newYVelocity = CalculateYVelocity();

            _rigidbody.velocity = new Vector2(newXVelocity, newYVelocity);

            _animator.SetBool(_isGroundHash, _check.IsTouchingCollider);
            _animator.SetBool(_isRunningHash, _direction.x != 0);
            _animator.SetFloat(_isFallingHash, _rigidbody.velocity.y);

            UpdateHeroFlip();
        }

        private float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumping = _direction.y > 0;

            #region Setting flag for double jump
            //if (_check.IsTouchingCollider) _allowDoubleJump = true;
            #endregion

            if (isJumping)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
            }
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            //var isFalling = _rigidbody.velocity.y <= 0.01f;

            var isChangingY = _rigidbody.velocity.y < -0.1 || _rigidbody.velocity.y > 0.1;

            if (isChangingY) return yVelocity;

            if (_check.IsTouchingCollider)
            {
                yVelocity += _jumpSpeed;
            }

            return yVelocity;
        }

        #region CalculateJumpVelocity() with double jump 
        //private float CalculateJumpVelocity(float yVelocity)
        //{
        //    //var isMoveY = _rigidbody.velocity.y < -0.1 || _rigidbody.velocity.y > 0.1;

        //    var isFalling = _rigidbody.velocity.y <= 0.001f;
        //    if (!isFalling) return yVelocity;

        //    if (_check.IsTouchingCollider)
        //    {
        //        yVelocity += _jumpingSpeed;
        //    }
        //    else if (_allowDoubleJump)
        //    {
        //        yVelocity = _jumpingSpeed;
        //        _allowDoubleJump = false;
        //    }

        //    return yVelocity;
        //}
        #endregion

        private void UpdateHeroFlip()
        {
            if (_direction.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_direction.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
        }

        public void TellSomething()
        {
            //Debug.Log("I'm pirate!!!");
            Debug.Log(_scoreComponent.GetScore());
        }

        public void Interact()
        {
            #region Raycast for interaction
            //var raycastHit = Physics2D.Raycast(transform.position, _spriteRenderer.flipX ? Vector2.left : Vector2.right, _interactDistance, _interactableLayer);
            //var collider = raycastHit.collider;

            //if (collider != null && collider.TryGetComponent(out InteractableComponent interactable))
            //{
            //    interactable.Interact();
            //}
            #endregion

            var size = Physics2D.RaycastNonAlloc(transform.position, _spriteRenderer.flipX ? Vector2.left : Vector2.right, _hits, _interactDistance, _interactableLayer);

            for (int i = 0; i < size; i++)
            {
                _hits[i].transform.GetComponent<InteractableComponent>().Interact();
            }
        }

        public void OnTakeDamage()
        {
            _animator.SetTrigger(_hit);

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpSpeed);
        }

        #region CircleCast
        //private bool IsGrounded()
        //{
        //    return Physics2D.CircleCast(transform.position,_groundCheckRadius,Vector2.down, _groundCheckRadius, _groundLayer);
        //}

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = IsGrounded() ? Color.green : Color.red;
        //    Gizmos.DrawSphere(transform.position + _groundCheckPositionDelta, _groundCheckRadius);
        //}
        #endregion

        #region Raycast
        //private bool IsGrounded()
        //{
        //    return Physics2D.Raycast(transform.position, Vector2.down, 1f, _groundLayer);
        //}

        //private void OnDrawGizmos()
        //{
        //    Debug.DrawRay(transform.position, Vector2.down, IsGrounded() ? Color.green : Color.red);
        //}
        #endregion
    }
}


