using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Food : MovingAgent
    {
        public bool IsCaptured;
        public bool isRotten { get; private set; }
        private FoodType _foodType;
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