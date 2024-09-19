using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject
{
    public GameObject FindTarget(TargetType targetType, Vector2 myPos, float range, LayerMask layerMask)
    {
        GameObject target = null;
        var hitColliders = Physics2D.OverlapCircleAll(myPos, range, layerMask);
        switch (targetType)
        {
            case TargetType.Nearest:
                target = FindNearestObjectWithTag(hitColliders, myPos);
                break;

            case TargetType.LeastHp:
                target = FindLeastAmountOfHp(hitColliders, myPos);
                break;
            case TargetType.MostHp:
                target = FindMostAmountOfHp(hitColliders, myPos);
                break;
            default:
                break;
        }
        
        //GameObject target = FindNearestObjectWithTag(hitColliders, myPos);
        //GameObject target = FindLeastAmountOfHp(hitColliders, myPos);
        return target;
    }
    public GameObject FindNearestObjectWithTag(Collider2D[] allTargets, Vector2 myPos)
    {
        GameObject nearestEnemy = null;
        //GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(tag);
        Collider2D[] allEnemies = allTargets;
        float distance = Mathf.Infinity;
        foreach (var go in allEnemies)
        {
            Vector2 diff = (Vector2)go.transform.position - myPos;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                nearestEnemy = go.gameObject;
                distance = curDistance;
            }
        }
        return nearestEnemy;
    }

    public GameObject FindLeastAmountOfHp(Collider2D[] allTargets, Vector2 myPos)
    {

        GameObject target = null;

        float hp = Mathf.Infinity;
        foreach (var go in allTargets)
        {
            float currentHp = go.GetComponent<Health>().CurrentHealth;
            if (currentHp < hp)
            {
                target = go.gameObject;
                hp = currentHp;
            }
        }

        return target;
    }

    public GameObject FindMostAmountOfHp(Collider2D[] allTargets, Vector2 myPos)
    {
        GameObject target = null;

        float hp = 0f;
        foreach (var go in allTargets)
        {
            float currentHp = go.GetComponent<Health>().CurrentHealth;
            if (currentHp > hp)
            {
                target = go.gameObject;
                hp = currentHp;
            }
        }

        return target;
    }

}
