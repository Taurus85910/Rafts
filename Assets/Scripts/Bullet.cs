using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _targetYPosition;

    private float _flyTime;
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _flyTime)
        {
            _elapsedTime = 0;
            DisableBullet();
        }
    }

    public void MoveToTarget(Transform target)
    {
        _flyTime = (target.position - transform.position).magnitude / _speed;
        transform.DOMove(new Vector3(target.position.x, _targetYPosition , target.position.z), _flyTime);
    }

    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
