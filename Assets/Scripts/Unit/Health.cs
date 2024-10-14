using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    public Action onDead;

    private UnitParameters _unitParameters;

    public float StartHealth { get => _unitParameters.CurrentMaxHealth; set => _unitParameters.CurrentMaxHealth = value; }
    public float CurrentHealth { get; private set; }
    public bool IsAlive { get; private set; } = true;

    private void Start()
    {
        _unitParameters = GetComponent<UnitParameters>();
        StartHealth = _unitParameters.StartMaxHealth;
        CurrentHealth = StartHealth;
    }
    private void FixedUpdate()
    {
        if (IsAlive)
        {
            CurrentHealth = Math.Min(CurrentHealth + _unitParameters.CurrentRegenerationHealth * Time.fixedDeltaTime, StartHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        
        if(CurrentHealth <= 0f)
        {
            IsAlive = false;
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
        StartHealth = _unitParameters.CurrentMaxHealth;
    }
}
