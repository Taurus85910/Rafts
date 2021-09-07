using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private DirectionTracker _directionTracker;
    
    private void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, 
           transform.position + _directionTracker.GetDirection(), _speed * Time.deltaTime);
    }
}
