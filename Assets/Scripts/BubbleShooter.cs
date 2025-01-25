using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Bubble bubblePrefab;

    private Vector3 _currentDirection;

    private float _bubbleSpeed = 10f;

    private float _bubbleSpeedIncrease = 3f;
    
    
    private void OnEnable()
    {
        LevelManager.GameSpeedUp += SpeedUp;
    }
        
    private void OnDisable()
    {
        LevelManager.GameSpeedUp -= SpeedUp;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateDirectionWithMouse();
            ShootProjectile();
        }
    }
    
    public void UpdateDirectionWithMouse()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Vector3 directionToMouse = mouseWorldPosition - transform.position;

        _currentDirection = directionToMouse.normalized;
    }

    
    private void ShootProjectile()
    {
        if (_currentDirection != Vector3.zero)
        {
            Bubble bubble = Instantiate(bubblePrefab, shootPoint.position, Quaternion.identity);
            bubble.Initialize(_currentDirection);
            bubble.MoveSpeed = _bubbleSpeed;
        }
    }

    private void SpeedUp()
    {
        _bubbleSpeed += _bubbleSpeedIncrease;
    }

}
