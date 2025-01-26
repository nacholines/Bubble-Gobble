using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class FoodEaterAnimator : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Health = Animator.StringToHash("Health");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Bubble.FoodCaptured += HandleFoodCaptured;
        FoodEater.FoodEaten += HandleFoodEaten;
    }
    
    private void OnDisable()
    {
        Bubble.FoodCaptured -= HandleFoodCaptured;
        FoodEater.FoodEaten -= HandleFoodEaten;
    }

    private void HandleFoodCaptured()
    {
        _animator.SetBool("IsMouthOpen", true);
    }

    private void HandleFoodEaten(bool goodFood)
    {
        _animator.SetBool("IsMouthOpen", false);

        if (goodFood) return;

        var currentHealth = _animator.GetInteger("Health") - 1;
        _animator.SetInteger("Health", currentHealth);
    }
}
