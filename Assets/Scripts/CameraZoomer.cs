using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoomer : MonoBehaviour
{
    [SerializeField] private float _battleZoomValue;
    [SerializeField] private float _zoomSpeed;
    
    private Camera _camera;
    private float _startZoomValue;
    private float _targetValue;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _startZoomValue = _camera.fieldOfView;
        _targetValue = _startZoomValue;
    }
    
    private void Update()
    {
        _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView, _targetValue,_zoomSpeed * Time.deltaTime);
    }
    
    public void Zoom()
    {
        _targetValue = _battleZoomValue;
    }

    public void Unzoom()
    {
        _targetValue = _startZoomValue;
    }
}
