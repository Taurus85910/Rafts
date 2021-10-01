using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    [SerializeField] private Material _material;

    private bool _isCapture = false;

    public bool IsCapture => _isCapture;
    
    public void ChangeColor()
    {
        foreach (Block block in GetComponentsInChildren<Block>())
        {
            block.gameObject.GetComponent<MeshRenderer>().material = _material;
        }
    }

    public void Capture()
    {
        _isCapture = true;
    }
}
