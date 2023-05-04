using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class ColliderCheck : MonoBehaviour
    {
        private Collider2D _collider;

        public bool IsTouchingCollider { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            IsTouchingCollider = _collider.IsTouching(collision) && !collision.isTrigger;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IsTouchingCollider = _collider.IsTouching(collision);
        }
    }
}
