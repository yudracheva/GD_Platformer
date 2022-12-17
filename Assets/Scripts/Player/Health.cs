using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private GameObject _deadPanel;
    [SerializeField] private GameObject[] _othersPanel;
    
    private float _currentHealth;
    public bool IsAlive { get; private set; }
    private Animator _currentAnimation;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        IsAlive = true;
        _currentAnimation = GetComponent<Animator>();
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
    
    public float GetPercentageOfCurrentHealth()
    {
        return _currentHealth / _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentAnimation.SetBool("isHurt", true);
        CheckIsAlive();
        if (!IsAlive)
        {
            _deadPanel.SetActive(true);
            foreach (var panel in _othersPanel)
            {
                panel.SetActive(false);
            }
        }
    }

    private void CheckIsAlive()
    {
        IsAlive = _currentHealth > 0;
    }
}
