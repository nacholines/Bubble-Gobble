using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Food : MovingAgent
    {
        public bool isRotten { get; private set; }
        public FoodType foodType;
        public Bubble Bubble;

        private void OnDestroy()
        {
            if (Bubble is null) return;
            Destroy(Bubble);
        }
    }

    public enum FoodType
    {
        burger,
        banana,
        croissant,
        lettuce,
        chicken,
        cherry
    }
}