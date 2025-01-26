using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bubble : MovingAgent
    {
        public static event Action FoodCaptured;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Food>(out var food))
            {
                CaptureFood(food);
            }
        }

        private void CaptureFood(Food capturedFood)
        {
            if (capturedFood.IsCaptured || IsCaptured) return;
            
            capturedFood.gameObject.transform.SetParent(gameObject.transform);
            capturedFood.MoveSpeed = 0f;
            capturedFood.transform.position = transform.position;
            capturedFood.IsCaptured = true;
            capturedFood.Bubble = this;
            IsCaptured = true;
            FoodCaptured?.Invoke();
            
            MoveSpeed = 3f;
            direction = Vector3.down;
        }
    }
}