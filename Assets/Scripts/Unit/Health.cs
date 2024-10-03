using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    public Action onDead;

    private float _startHealth;
    private float _currentHealth;
    private UnitParameters _unitParameters;

    public float CurrentHealth { get => _currentHealth; }
    public float StartHealth { get => _startHealth; set => _startHealth = value; }

    private void Start()
    {
        _unitParameters = GetComponent<UnitParameters>();
        _startHealth = _unitParameters.StartMaxHealth;
        _currentHealth = _startHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        
        if(_currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        onDead?.Invoke();
        Destroy(gameObject);
    }

    public void UpdateMaxHP()
    {
        _startHealth = _unitParameters.CurrentMaxHealth;
    }
}
