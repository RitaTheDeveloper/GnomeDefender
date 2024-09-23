using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private float _startHealth;
    private float _currentHealth;
    private UnitParameters _unitParameters;

    public float CurrentHealth { get => _currentHealth; }
    public float StartHealth { get => _startHealth; set => _startHealth = value; }

    private void Start()
    {
        _unitParameters = GetComponent<UnitParameters>();
        _startHealth = _unitParameters.StartHealth;
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
        Destroy(gameObject);
    }
}
