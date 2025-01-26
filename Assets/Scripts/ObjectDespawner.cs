using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectDespawner : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("despawning object collider");
            Destroy(other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("despawning object trigger");
            Destroy(other.gameObject);
        }
    }
}