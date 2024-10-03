using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLevelController : MonoBehaviour, ILevelSystem
{
    public Action OnAddExp;
    public Action onLevelUp;
    [field: SerializeField] public int StartLevel { get; set; } = 1;
    [field: SerializeField] public float BaseValue { get; set; } = 15f;
    [field: SerializeField] public float LevelValue { get; set; } = 6f;
    public int CurrentLevel { get; set; }

    public float ExpNeededForLevelUp { get; private set; }
    public float CurrentExp { get; set; }

    private void OnEnable()
    {
        Actions.OnEnemyKilled += AddExperience;
    }

    private void OnDisable()
    {
        Actions.OnEnemyKilled -= AddExperience;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        CurrentLevel = StartLevel;
        CurrentExp = 0f;
        ExpNeededForLevelUp = GetExpNeededForLevelUp(CurrentLevel);
    }

    public void AddExperience(float exp)
    {
        CurrentExp += exp;
        if (CurrentExp >= ExpNeededForLevelUp)
        {
            LevelUp();
        }
        OnAddExp.Invoke();
    }

    public void LevelUp()
    {
        CurrentLevel++;
        CurrentExp -= ExpNeededForLevelUp;
        ExpNeededForLevelUp = GetExpNeededForLevelUp(CurrentLevel);
        onLevelUp.Invoke();
    }

    public float GetExpNeededForLevelUp(int currentLvl)
    {
        return Formulas.ExpNeededForLevelUp(BaseValue, LevelValue, currentLvl);
    }
}
