using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint; 
    [SerializeField] private List<Bullet> _bulletPull;

    private void Start()
    {
        _bulletPull = GetComponentsInChildren<Bullet>().ToList();
        _bulletPull.ForEach(bullet => bullet.gameObject.SetActive(false));
    }

    public void TakeShot(Transform target)
    {
          foreach (var bullet in _bulletPull)
          {
            if (bullet.gameObject.activeSelf == false)
            {
                bullet.gameObject.transform.position = _shootPoint.position;
                bullet.gameObject.SetActive(true);
                bullet.MoveToTarget(target);
                break;
            }
        }
        
    }
}
