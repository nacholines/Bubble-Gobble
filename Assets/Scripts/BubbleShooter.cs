using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bubblePrefab;

    private Vector3 _currentDirection;
    
    // Method to update cached direction based on mouse input
    public void UpdateDirectionWithMouse()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z; 
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Vector3 directionToMouse = mouseWorldPosition - transform.position;

        _currentDirection = directionToMouse.normalized;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateDirectionWithMouse();
            ShootProjectile();
        }
    }
    
    private void ShootProjectile()
    {
        Debug.Log("shooting Projectile");
        if (bubblePrefab != null && shootPoint != null && _currentDirection != Vector3.zero)
        {
            GameObject projectile = Instantiate(bubblePrefab, shootPoint.position, Quaternion.identity);
            var bubble = projectile.GetComponent<Bubble>();
            bubble.Initialize(_currentDirection);
        }
    }

}
