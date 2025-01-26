using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BubbleShooterAnimator : MonoBehaviour
    {
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            BubbleShooter.BubbleShot += PlayShootAnimation;
        }

        private void OnDisable()
        {
            BubbleShooter.BubbleShot -= PlayShootAnimation;
        }

        private void PlayShootAnimation(int index)
        {
            _animator.SetInteger("DirectionIndex", index);
            _animator.SetTrigger("Shoot");
        }
    }
}