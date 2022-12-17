using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    public bool IsAlive { get; private set; }
    private Animator _currentAnimation;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        IsAlive = true;
        _currentAnimation = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentAnimation.SetBool("isHurt", true);
        CheckIsAlive();
        if (!IsAlive)
        {
            
        }
    }

    private void CheckIsAlive()
    {
        IsAlive = _currentHealth > 0;
    }
}
