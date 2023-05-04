using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components
{
    public class EnterCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private CollisionEvent _action;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                _action?.Invoke(collision.gameObject);
            }
        }

        [Serializable] private sealed class CollisionEvent : UnityEvent<GameObject> { }
    }            
}