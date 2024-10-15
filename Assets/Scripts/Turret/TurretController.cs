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
        return (_townUnitParameters.CurrentDamage + _unitParameters.CurrentDamage);
    }
}  
