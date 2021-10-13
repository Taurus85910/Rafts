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
    [SerializeField] private float _flashDuration;
    
    private Weapon _weapon;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private int _currentHealth;
    private bool _isAlive = true;
    private Coroutine _routine;
    private Color _originalColor;

    public bool IsAlive => _isAlive;

    public DwellerBody DwellerBody => _dwellerBody;
    
    private void Start()
    {
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        _weapon = GetComponentInChildren<Weapon>();
        PutWeaponAway();
        _originalColor = _skinnedMeshRenderer.material.color;
        _routine = StartCoroutine(Flash(_originalColor));
        _currentHealth = _maxHealth;
    }

    public void AppleDamage(int damage)
    {
        _currentHealth -= damage;
        StopCoroutine(_routine);
        _routine = StartCoroutine(Flash(Color.white));
        if (_currentHealth <= 0)
        {
            Die();
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
        _originalColor = _skinnedMeshRenderer.material.color;
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

    private void Die()
    {
        _isAlive = false;
        _skinnedMeshRenderer.enabled = false;
        PutWeaponAway();
    }
    
    private IEnumerator Flash(Color color)
    {
        _skinnedMeshRenderer.material.color = color;
        yield return new WaitForSeconds(_flashDuration);
        _skinnedMeshRenderer.material.color = _originalColor;
    }
    
}
