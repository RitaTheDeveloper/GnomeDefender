using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParameters : MonoBehaviour
{
    [Tooltip("кол-во атак в секунду")]
    [field: SerializeField] public float StartAttackSpeed { get; set; }
    [field: SerializeField] public float StartDamage { get; set; }
    [field: SerializeField] public float StartAttackRange { get; set; }
    [field: SerializeField] public float StartMaxHealth { get; set; }
    [field: SerializeField] public float StartRegenerationHealth { get; set; }
    [field: SerializeField] public float ExpForKill { get; set; }

    public float CurrentMaxHealth { get; set; }
    public float CurrentDamage { get; set; }
    public float CurrentRegenerationHealth { get; set; }
    public float CurrentAttackRange { get; set; }
    public float CurrentAttackSpeed { get; set; }

    private void Start()
    {
        CurrentMaxHealth = StartMaxHealth;
        CurrentDamage = StartDamage;
        CurrentRegenerationHealth = StartRegenerationHealth;
        CurrentAttackRange = StartAttackRange;
        CurrentAttackSpeed = StartAttackSpeed;
    }
}
