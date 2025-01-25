using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MovingAgent : MonoBehaviour
    {
        public float MoveSpeed;
        
        protected Vector3 direction;
        
        public void Initialize(Vector3 direction)
        {
            this.direction = direction.normalized;
        }

        private void Update()
        {
            Vector3 newPosition = transform.position + direction * MoveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}