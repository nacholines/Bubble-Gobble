using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MovingAgent : MonoBehaviour
    {
        public float MoveSpeed;
        public bool IsCaptured;
        
        protected Vector3 direction;
        
        public void Initialize(Vector3 direction)
        {
            this.direction = direction.normalized;
        }

        private void OnEnable()
        {
            LevelManager.GameSpeedUp += SpeedUp;
        }
        
        private void OnDisable()
        {
            LevelManager.GameSpeedUp -= SpeedUp;
        }
        
        private void Update()
        {
            Vector3 newPosition = transform.position + direction * MoveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }

        protected void SpeedUp()
        {
            if (IsCaptured) return;
            MoveSpeed += 3f;
        }
    }
}