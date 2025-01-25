using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bubble : MovingAgent
    {
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
            IsCaptured = true;
            
            MoveSpeed = 1f;
            direction = Vector3.down;
        }
    }
}