using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelManager : MonoBehaviour
    {
        public static event Action GameSpeedUp;
        public static event Action<int> HealthChanged;
        public static event Action GameFinished;

        [SerializeField] private int gameSpeedUpThreshold = 3;
        [SerializeField] private FoodSpawner foodSpawner;

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject gameFinishedScreen;
        
        private int score = 0;

        private int currentHealth = 3;

        private int foodEaten = 0;

        private int currentStage = 0;
        private int maxStage = 5;

        private void Awake()
        {
            gameFinishedScreen.SetActive(false);
        }

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
            HealthChanged?.Invoke(currentHealth);

            if (currentHealth == 0)
            {
                GameFinished?.Invoke();
                gameFinishedScreen.SetActive(true);
                Debug.Log("You lost!");
            }
        }

        private void GoodFoodEaten()
        {
            score += 100;
            scoreText.text = score.ToString();
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

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}