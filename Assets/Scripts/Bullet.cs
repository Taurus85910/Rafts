using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _impactSystem;
    [SerializeField] private float _targetYPosition;
    [SerializeField] private Transform _impactDirection;

    private float _flyTime;
    private float _elapsedTime;
    private Transform _startPosition;
    
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _flyTime)
        {
            _elapsedTime = 0;
            DisableBullet();
        }
    }

    private void OnEnable()
    {
        _startPosition = transform;
    }

    private void DisableBullet()
    {
        _impactSystem.gameObject.transform.position = transform.position;
        _impactSystem.gameObject.transform.TransformVector(_impactDirection.position.normalized * 3);
        _impactSystem.gameObject.transform.rotation = _impactDirection.rotation;
        
        _impactSystem.Stop();
        _impactSystem.Play();
        gameObject.SetActive(false);
    }

    public void MoveToTarget(Transform target)
    {
        _flyTime = (target.position - transform.position).magnitude / _speed;
        transform.DOMove(new Vector3(target.position.x, _targetYPosition , target.position.z), _flyTime);
    }

    
}
