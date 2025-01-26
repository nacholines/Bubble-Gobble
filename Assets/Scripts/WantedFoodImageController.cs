using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class WantedFoodImageController : MonoBehaviour
    {
        [SerializeField] private Sprite burgerSprite;
        [SerializeField] private Sprite bananaSprite;
        [SerializeField] private Sprite croissantSprite;
        [SerializeField] private Sprite lettuceSprite;
        [SerializeField] private Sprite chickenSprite;
        [SerializeField] private Sprite cakeSprite;
        [SerializeField] private Sprite cherrySprite;

        private Image _wantedFoodImage;
        
        private void Awake()
        {
            _wantedFoodImage = GetComponent<Image>();
        }

        private void OnEnable()
        {
            FoodEater.WantedFoodSet += SetSpriteForFood;
        }
        
        private void OnDisable()
        {
            FoodEater.WantedFoodSet -= SetSpriteForFood;
        }

        private void SetSpriteForFood(FoodType foodType)
        {
            var sprite = GetSpriteForFood(foodType);
            _wantedFoodImage.sprite = sprite;
        }

        public Sprite GetSpriteForFood(FoodType foodType)
        {
            switch (foodType)
            {
                case FoodType.burger:
                    return burgerSprite;
                case FoodType.banana:
                    return bananaSprite;
                case FoodType.croissant:
                    return croissantSprite;
                case FoodType.lettuce:
                    return lettuceSprite;
                case FoodType.chicken:
                    return chickenSprite;
                case FoodType.cake:
                    return cakeSprite;
                case FoodType.cherry:
                    return cherrySprite;
                default:
                    return null; // Return null if no sprite is assigned
            }
        }
    }
}