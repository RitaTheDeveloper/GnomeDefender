using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Ability
{
    [SerializeField] private GameObject shellprefab;
    private GameObject shell;
    Vector2 direction;

    public override void Execute(IAttacker attacker, IDamageable target)
    {
        //RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);
        //if (hit) // If this is true then it hits something
        //{
        //    Debug.Log("Hit " + hit.collider.gameObject);
        //}
        Component Target = (Component)target;
        Component Attacker = (Component)attacker;
        float damage = Attacker.GetComponent<UnitParameters>().Damage;
        direction = Target.transform.position - Attacker.transform.position;
        shell = Instantiate(shellprefab, Attacker.transform.position, Quaternion.identity);
        shell.GetComponent<Shell>().Init(direction, damage);
    }

}
