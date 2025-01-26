using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioSource music;
        [SerializeField] private float targetPitch = 2.0f; // Maximum pitch value
        [SerializeField] private float pitchChangeInterval = 0.4f; // Fixed increment
        [SerializeField] private float intervalDuration = 0.5f; // Time between increments

        private Coroutine pitchCoroutine;

        private void OnEnable()
        {
            LevelManager.GameSpeedUp += SpeedUpMusic;
        }

        private void OnDisable()
        {
            LevelManager.GameSpeedUp -= SpeedUpMusic;
        }

        private void SpeedUpMusic()
        {
            if (music == null)
            {
                Debug.LogWarning("AudioSource is not assigned!");
                return;
            }

            // Stop any existing coroutine to avoid overlapping adjustments
            if (pitchCoroutine != null)
            {
                StopCoroutine(pitchCoroutine);
            }

            // Start a new coroutine to adjust the pitch
            pitchCoroutine = StartCoroutine(IncreasePitchInIntervals());
        }

        private IEnumerator IncreasePitchInIntervals()
        {
            while (music.pitch < targetPitch)
            {
                // Increase pitch by the fixed interval
                music.pitch += pitchChangeInterval;

                // Clamp the pitch to ensure it doesn't exceed the target
                if (music.pitch > targetPitch)
                {
                    music.pitch = targetPitch;
                    break; // Exit the loop once the target is reached
                }

                // Wait for the interval duration before the next increment
                yield return new WaitForSeconds(intervalDuration);
            }

            pitchCoroutine = null; // Clear the coroutine reference
        }
    }
}