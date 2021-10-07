using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public event Action RaftFound;

    private SpriteRenderer _gridSprite;

    private void Start()
    {
        _gridSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Raft raft))
        {
            _gridSprite.enabled = false;
            if (raft.IsCapture)
            {
                RaftFound?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _gridSprite.enabled = true;
    }
}
