using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

namespace DefaultNamespace
{
    public class FoodEater : MonoBehaviour
    {
        public static event Action<bool> FoodEaten;
        public static event Action<FoodType> WantedFoodSet;

        private FoodType wantedFoodType;

        [SerializeField] private Image wantedFoodSprite;

        [SerializeField] private Sprite burgerSprite;
        [SerializeField] private Sprite bananaSprite;
        [SerializeField] private Sprite croissantSprite;
        [SerializeField] private Sprite lettuceSprite;
        [SerializeField] private Sprite chickenSprite;
        [SerializeField] private Sprite cakeSprite;
        [SerializeField] private Sprite cherrySprite;
        
        private void Awake()
        {
            SetWantedFood();
        }

        private void SetWantedFood()
        {
            wantedFoodType = GetRandomFood();
            WantedFoodSet?.Invoke(wantedFoodType);
        }
        
        private FoodType GetRandomFood()
        {
            // Get all values of the FoodType enum
            FoodType[] foodTypes = (FoodType[])System.Enum.GetValues(typeof(FoodType));
            
            // Select a random index from the array
            int randomIndex = UnityEngine.Random.Range(0, foodTypes.Length);

            // Return the randomly selected FoodType
            return foodTypes[randomIndex];
        }

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
            Destroy(capturedFood.Bubble.gameObject);
            if (food.isRotten || food.foodType != wantedFoodType)
            {
                HandleBadFood();
                return;
            }
            
            Debug.Log("good food!");
            FoodEaten?.Invoke(true);
            SetWantedFood();
        }

        private void HandleBadFood()
        {
            Debug.Log("bad food!");
            FoodEaten?.Invoke(false);
            SetWantedFood();
        }
    }
}