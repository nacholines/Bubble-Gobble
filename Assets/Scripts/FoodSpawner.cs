using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] private List<Food> foodPrefabs;
        [SerializeField] private float spawnRate;

        private void Start()
        {
            StartCoroutine(FoodSpawningCoroutine());
        }

        private IEnumerator FoodSpawningCoroutine()
        {
            SpawnRandomFood();
            yield return new WaitForSeconds(spawnRate);
            StartCoroutine(FoodSpawningCoroutine());
        }

        private void SpawnRandomFood()
        {
            int randomIndex = Random.Range(0, foodPrefabs.Count);

            Food selectedFood = foodPrefabs[randomIndex];

            Food food = Instantiate(selectedFood, transform.position, Quaternion.identity);
            food.Initialize(Vector3.left);
        }
    }
}