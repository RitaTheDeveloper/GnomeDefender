using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Perks/BaseParameter", fileName = "BaseParameterConfig")]
public class AddBaseParameterConfig : PerkConfig
{
    [field: SerializeField] public TargetForEnemyType Target { get; private set; }
    [field: SerializeField] public UnitParameterType ParameterType { get; private set; }
    //[field: SerializeField] public float Value { get; private set; }

    public override void Init()
    {
        AddBaseParameterPerk basePerk = new AddBaseParameterPerk(Target, ParameterType, Value);
        SetPerk(basePerk);
        base.Init();
    }
}
