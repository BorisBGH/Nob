using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action<float, float> OnHealthChange; 

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private void Start()
    {
        SetHealth(_maxHealth);
    }

    public void TakeDamage(float  damage)
    {
        float newHealth = _currentHealth - damage;
        newHealth = Mathf.Max(newHealth, 0f);
        SetHealth(newHealth);
        if (_currentHealth == 0f)
        {
            Die();
        }
    }

    private void SetHealth(float value)
    {
        _currentHealth = value;
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }

    private void Die()
    {
        Debug.Log("dead");
    }
}
