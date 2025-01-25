using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class FoodSpawner : MonoBehaviour
    {
        public float SpawnRate;
        public float FoodSpeed;
        
        [SerializeField] private List<Food> foodPrefabs;
        
        private float maxFoodSpeed = 10f; 
        private float minSpawnRate = 0.3f;
        
        float foodSpeedIncrease = 1f;
        float spawnRateDecrease = 0.4f; 

        private void Start()
        {
            StartCoroutine(FoodSpawningCoroutine());
        }

        private void OnEnable()
        {
            LevelManager.GameSpeedUp += IncreaseSpawnSpeed;
        }
        
        private void OnDisable()
        {
            LevelManager.GameSpeedUp -= IncreaseSpawnSpeed;
        }

        private IEnumerator FoodSpawningCoroutine()
        {
            SpawnRandomFood();
            yield return new WaitForSeconds(SpawnRate);
            StartCoroutine(FoodSpawningCoroutine());
        }

        private void SpawnRandomFood()
        {
            int randomIndex = Random.Range(0, foodPrefabs.Count);

            Food selectedFood = foodPrefabs[randomIndex];

            Food food = Instantiate(selectedFood, transform.position, Quaternion.identity);
            food.Initialize(Vector3.left);
            food.MoveSpeed = FoodSpeed;
        }

        private void IncreaseSpawnSpeed()
        {
            FoodSpeed = Mathf.Min(FoodSpeed + foodSpeedIncrease, maxFoodSpeed);
            SpawnRate = Mathf.Max(SpawnRate - spawnRateDecrease, minSpawnRate);
        }
    }
}