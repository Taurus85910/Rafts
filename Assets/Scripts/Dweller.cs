using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class Dweller : MonoBehaviour
{
   [SerializeField] private int _maxHealth;
   [SerializeField] private int _damage;
   [SerializeField] private Animator _animator;
   
   private SkinnedMeshRenderer _skinnedMeshRenderer;
   private int _currentHealth;
   private bool _isDead;

   public SkinnedMeshRenderer SkinnedMeshRenderer => _skinnedMeshRenderer;

   public bool IsDead => _isDead;
   public int Damage => _damage;

   public event Action Die;

   private void Start()
   {
      _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
      _animator.SetBool("IsFighting",false);
   }

   public void ApplyDamage(int damage)
   {
      _currentHealth -= damage;

      if (_currentHealth <= 0)
      {
         Die?.Invoke();
         _isDead = true;
         _skinnedMeshRenderer.enabled = false;
      }
   }

   public void ResetDweller()
   {        
      _skinnedMeshRenderer.enabled = true;
      _currentHealth = _maxHealth;
      _isDead = false;
   }

   public void EnterBattle()
   {
      _animator.SetBool("IsFighting", true);
   }

   public void ExitBattle()
   {
      _animator.SetBool("IsFighting",false);
   }
   
}
