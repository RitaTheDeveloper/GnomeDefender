using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineTheTarget
{
    public GameObject FindTargetAtScene(TargetForEnemyType type)
    {
        GameObject target = null;
        switch (type)
        {
            case TargetForEnemyType.Player:
                target = GameObject.FindGameObjectWithTag("Player");
                break;

            case TargetForEnemyType.Town:
                target = GameObject.FindGameObjectWithTag("Town");
                break;            
            default:
                break;
        }
        return target;
    }
}

[System.Serializable]
public class TargetTypeAndDetectionRadius
{
    public TargetForEnemyType targetType;
    public float detectionRadius;
}

