using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bubble : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;

        private Vector3 _direction;
        
        public void Initialize(Vector3 direction)
        {
            _direction = direction.normalized;
        }

        private void Update()
        {
            Vector3 newPosition = transform.position + _direction * _moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}