using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider))]
public class RaftConnector : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    [SerializeField] private float _connectDuration;

    private Vector3 _targetPosition;
    private BoxCollider _boxCollider;
    private Coroutine _routine;

    public event Action<MainRaft> RaftConnected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Raft raft) && !raft.IsCapture)
        {
            MainRaft mainRaft = raft.GetComponentInParent<MainRaft>();
            _targetPosition = new Vector3(Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize, 0,
                Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize);

            transform.DOMove(_targetPosition, _connectDuration);
            RaftConnected?.Invoke(mainRaft);

           // _routine = StartCoroutine(StartBattle(mainRaft));
        }
    }
    
    private IEnumerator StartBattle(MainRaft mainRaft)
    {
        yield return new WaitForSeconds(_connectDuration);
        
    }
    
    public void Connecting(MainRaft mainRaft)
    {
        //StopCoroutine(_routine);
        transform.position = _targetPosition;
        mainRaft.GetRafts.ForEach(raft => raft.gameObject.transform.parent = transform);
    }
}
