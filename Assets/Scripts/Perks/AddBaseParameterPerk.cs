using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBaseParameterPerk : Perk
{
    public float Value { get; private set; }
    private UnitParameters _targetParameters;
    private UnitParameterType _parameterType;
    public AddBaseParameterPerk(TargetForEnemyType target, UnitParameterType parameterType, float value)
    {
        Value = value;
        _parameterType = parameterType;
        DefineTheTarget dt = new DefineTheTarget();
        _targetParameters = dt.FindTargetAtScene(target).GetComponent<UnitParameters>();
    }

    public override void AddPerk()
    {
        if (_targetParameters)
        {
            AddBonusToParameters.AddBonus(_targetParameters, _parameterType, Value);
        }
    }
}
