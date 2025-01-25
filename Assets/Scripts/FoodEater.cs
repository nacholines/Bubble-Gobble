using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class FoodEater : MonoBehaviour
    {
        public static event Action FoodEaten;

        [SerializeField] private FoodType wantedFoodType;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Food>(out var food))
            {
                TryEatFood(food);
            }
        }

        private void TryEatFood(Food capturedFood)
        {
            var food = capturedFood;
            Destroy(capturedFood.gameObject);
            if (capturedFood.isRotten || capturedFood.foodType == wantedFoodType)
            {
                HandleBadFood();
                return;
            }

            Debug.Log("good food!");
            FoodEaten?.Invoke();
        }

        private void HandleBadFood()
        {
            Debug.Log("bad food!");
        }
    }
}