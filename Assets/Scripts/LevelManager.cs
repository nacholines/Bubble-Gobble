using System;
using JetBrains.Annotations;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour
    {
        public static event Action GameSpeedUp;
        
        [SerializeField] private int gameSpeedUpThreshold = 3;
        [SerializeField] private FoodSpawner foodSpawner;
        
        private int score = 0;

        private int currentHealth = 3;

        private int foodEaten = 0;

        private int currentStage = 0;
        private int maxStage = 5;

        private void OnEnable()
        {
            FoodEater.FoodEaten += HandleFoodEaten;
        }
        
        private void OnDisable()
        {
            FoodEater.FoodEaten -= HandleFoodEaten;
        }

        private void HandleFoodEaten(bool isGood)
        {
            if (isGood)
            {
                GoodFoodEaten();
                return;
            }

            currentHealth--;

            if (currentHealth == 0)
            {
                Debug.Log("You lost!");
            }
        }

        private void GoodFoodEaten()
        {
            score += 100;
            foodEaten++;
            Debug.Log(score);
            if (foodEaten % gameSpeedUpThreshold == 0)
            {
                IncreaseDifficulty();
            }
        }
        
        void IncreaseDifficulty()
        {
            if (currentStage == maxStage) return;
            
            currentStage++;
            GameSpeedUp?.Invoke();
        }
    }
}