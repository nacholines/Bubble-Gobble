using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    public static event Action<int> BubbleShot;
    
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Bubble bubblePrefab;

    private Vector3 _currentDirection;

    private float _bubbleSpeed = 10f;

    private float _bubbleSpeedIncrease = 3f;
    
    private const float AngleRange = 150f;
    private const int SegmentCount = 5;
    
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
            int segmentIndex = CalculateDirectionSegment(_currentDirection);
            BubbleShot?.Invoke(segmentIndex);
            
            Bubble bubble = Instantiate(bubblePrefab, shootPoint.position, Quaternion.identity);
            bubble.Initialize(_currentDirection);
            bubble.MoveSpeed = _bubbleSpeed;
        }
    }
    
    private int CalculateDirectionSegment(Vector3 direction)
    {
        float angle = Vector3.SignedAngle(direction, Vector3.up, Vector3.forward);

        float normalizedAngle = Mathf.Clamp(angle, -AngleRange / 2, AngleRange / 2);

        float segmentSize = AngleRange / SegmentCount;
        int segmentIndex = Mathf.FloorToInt((normalizedAngle + (AngleRange / 2)) / segmentSize) + 1;

        return Mathf.Clamp(segmentIndex, 1, SegmentCount);  
    }

    private void SpeedUp()
    {
        _bubbleSpeed += _bubbleSpeedIncrease;
    }

}
