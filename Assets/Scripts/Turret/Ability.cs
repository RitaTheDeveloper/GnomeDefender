using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability 
{
    public abstract void Execute(IAttacker attacker, IDamageable target);
}
