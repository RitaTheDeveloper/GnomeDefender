using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelSystem
{
    int StartLevel { get; set; }
    int CurrentLevel { get; set; }
    float BaseValue { get; set; }
    float LevelValue { get; set; }
    float CurrentExp { get; set; }
    void AddExperience(float exp);
    void LevelUp();
}
