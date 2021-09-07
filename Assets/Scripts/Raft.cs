using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    [SerializeField] private EnemyRaft _enemyRaft;

    private bool _canCapture = false;

    public EnemyRaft EnemyRaft => _enemyRaft;
    public bool CanCapture => _canCapture;

    public void SetCaptureAvailable()
    {
         _canCapture = true;
    }

    private void Start()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize, 0 , 
            Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize );
    }
}
