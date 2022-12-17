using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float defaultTimeRemaining = 2;
    [SerializeField] private float defaultTimeFireRemaining = 1;
    [SerializeField] private float damage = 15;

    private float _timeRemaining;
    private bool _timerIsRunning = false;

    private float _timeFireRemaining;
    private bool _timerFireIsRunning = false;

    private Animator _animator;

    private void Awake()
    {
        _timeRemaining = defaultTimeRemaining;
        _timeFireRemaining = defaultTimeFireRemaining;
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Start()
    {
        _timerIsRunning = true;
    }

    void Update()
    {
        if (_timerFireIsRunning)
        {
            if (_timeFireRemaining > 0)
            {
                _timeFireRemaining -= Time.deltaTime;
            }
            else
            {
                _timeFireRemaining = 0;
                _timerFireIsRunning = false;
                _timerIsRunning = true;
                _timeRemaining = defaultTimeRemaining;
            }
        }

        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                _timeRemaining = 0;
                _timerIsRunning = false;

                _animator.SetTrigger("Fire");
                _timeFireRemaining = defaultTimeFireRemaining;
                _timerFireIsRunning = true;
            }
        }

        Debug.Log($"{_timerFireIsRunning} {_timeFireRemaining} {_timerIsRunning} {_timeRemaining}");
    }
}
