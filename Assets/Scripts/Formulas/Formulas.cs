using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Formulas
{
    public static float ExpNeededForLevelUp(float baseValue, float levelValue, int currentLevel)
    {
        return baseValue + levelValue * (float)currentLevel;
    }
}
