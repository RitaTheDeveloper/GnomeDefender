using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : Unit
{
    private UnitParameters _townUnitParameters;

    public void Init(UnitParameters townParameters)
    {
        _townUnitParameters = townParameters;
    }

    public override float GetDamage()
    {
        Debug.Log("damage = " + (_townUnitParameters.CurrentDamage + _unitParameters.CurrentDamage));
        return (_townUnitParameters.CurrentDamage + _unitParameters.CurrentDamage);
    }
}  
