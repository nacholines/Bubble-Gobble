using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class Food : MovingAgent
    {
        public bool IsCaptured;
        public bool isRotten { get; private set; }
        public FoodType foodType;
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