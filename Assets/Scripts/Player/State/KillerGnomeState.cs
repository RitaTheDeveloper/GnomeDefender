using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerGnomeState : IState
{
    GnomeSM _gnomeSM;
    SpriteRenderer _bodySR;
    Color _killerBodyColor = Color.yellow;
    Color _startingBodyColor;
    IAttacker _attacker;
    public KillerGnomeState(GnomeSM gnomeSM, SpriteRenderer spriteRenederer, IAttacker attacker)
    {
        _gnomeSM = gnomeSM;
        _bodySR = spriteRenederer;
        _attacker = attacker;
    }

    public void Enter()
    {
        _startingBodyColor = _bodySR.color;
        _bodySR.color = _killerBodyColor;
    }

    public void Exit()
    {
        _bodySR.color = _startingBodyColor;
    }

    public void FixedTick()
    {
        _attacker.Attacking();
    }

    public void Tick()
    {
        
    }
}
