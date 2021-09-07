using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class RaftConnector : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    [SerializeField] private int _connectionTime;

    private Raft _currentRaftConnection;
    
    
        
    public event Action<EnemyRaft> RaftsConnected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Raft raft))
        {
            Vector3 targetPosition = new Vector3(Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize, 0,
                Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize);

            transform.DOMove(targetPosition, _connectionTime);
            RaftsConnected?.Invoke(raft.EnemyRaft);
            print("connect");
            
            if (raft.CanCapture)
            {
                transform.position = targetPosition;
                print("capture");
                other.gameObject.transform.parent = transform;
            }
        }
    }
    
    
}
