using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectForDestroing;
        public void OnDestroyObject()
        {
            Destroy(_objectForDestroing);
        }
    }
}