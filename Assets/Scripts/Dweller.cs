using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class Dweller : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private Animator _animator;
    [SerializeField] private Material _material;
    [SerializeField] private DwellerBody _dwellerBody;

    private Weapon _weapon;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private int _currentHealth;
    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    public DwellerBody DwellerBody => _dwellerBody;

    private void Start()
    {
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        _weapon = GetComponentInChildren<Weapon>();
        PutWeaponAway();
        _currentHealth = _maxHealth;
    }

    public void AppleDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _isAlive = false;
            _skinnedMeshRenderer.enabled = false;
            PutWeaponAway();
        }
    }

    public void BeginShooting()
    {
        _animator.SetBool("IsFighting",true);
    }

    public void EndShooting()
    {
        _animator.SetBool("IsFighting",false);
    }

    public void ChangeColor()
    {
        _skinnedMeshRenderer.enabled = true;
        _skinnedMeshRenderer.material = _material;
    }

    public void RestoreHealth()
    {
        _currentHealth = _maxHealth;
        _isAlive = true;
    }

    public void GetWeapon()
    {
        _weapon.gameObject.SetActive(true);
    }

    public void PutWeaponAway()
    {
        _weapon.gameObject.SetActive(false);
    }

    public int Shoot(Transform target)
    {
        _weapon.TakeShot(target);
        return _damage;
    }
    
}
