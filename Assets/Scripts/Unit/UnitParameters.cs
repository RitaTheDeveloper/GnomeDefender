using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParameters : MonoBehaviour
{
    [field: SerializeField] public float StartCd { get; set; }
    [field: SerializeField] public float StartDamage { get; set; }
    [field: SerializeField] public float StartAttackRange { get; set; }
    [field: SerializeField] public float StartMaxHealth { get; set; }
    [field: SerializeField] public float StartRegenerationHealth { get; set; }
    [field: SerializeField] public float ExpForKill { get; set; }

    public float CurrentMaxHealth { get; set; }
    public float CurrentDamage { get; set; }
    public float CurrentRegenerationHealth { get; set; }
    public float CurrentAttackRange { get; set; }

    private void Start()
    {
        CurrentMaxHealth = StartMaxHealth;
        CurrentDamage = StartDamage;
        CurrentRegenerationHealth = StartRegenerationHealth;
        CurrentAttackRange = StartAttackRange;
    }
}
