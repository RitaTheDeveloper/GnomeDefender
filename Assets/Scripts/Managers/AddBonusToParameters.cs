using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AddBonusToParameters
{
    public static void AddBonus(UnitParameters unitParameters, UnitParameterType parameterType, float value)
    {
        switch(parameterType)
        {
            case UnitParameterType.MaxHealth:
                unitParameters.CurrentMaxHealth += value;
                break;
            case UnitParameterType.HealthRegeneration:
                unitParameters.CurrentRegenerationHealth += value;
                break;
            case UnitParameterType.Damage:
                unitParameters.CurrentDamage += value;
                break;
            case UnitParameterType.AttackRange:
                unitParameters.CurrentAttackRange += value;
                break;
            default:
                break;
        }
    }
}