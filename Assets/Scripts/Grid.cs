using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public event Action RaftFound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Raft raft) && raft.IsCapture)
        {
            RaftFound?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
