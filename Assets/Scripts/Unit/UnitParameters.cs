using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParameters : MonoBehaviour
{
    [SerializeField] private float _cd;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _startHealth;

    public float Cd { get => _cd; set => _cd = value; }
    public float Damage { get => _damage; set => _damage = value; }
    public float AttackRange { get => _attackRange; set => _attackRange = value; }
    public float StartHealth { get => _startHealth; set => _startHealth = value; }
}
