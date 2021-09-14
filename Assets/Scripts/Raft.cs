using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Raft : MonoBehaviour
{
    [SerializeField] private Material _material;

    private bool _isCapture = false;
    private MeshRenderer _meshRenderer;

    public bool IsCapture => _isCapture;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor()
    {
        _meshRenderer.material = _material;
    }

    public void Capture()
    {
        _isCapture = true;
    }
}
