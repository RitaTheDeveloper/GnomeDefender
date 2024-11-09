using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterEnemyState : IState
{
    private IAttacker _attacker;
    private SpriteRenderer _spriteRenderer;
    private EnemyMovement _enemyMovement;
    Color _hunterBodyColor = Color.red;
    Color _startingBodyColor;

    public HunterEnemyState(SpriteRenderer spriteRenderer, IAttacker attacker, EnemyMovement enemyMovement)
    {
        _attacker = attacker;
        _spriteRenderer = spriteRenderer;
        _enemyMovement = enemyMovement;
    }
    public void Enter()
    {
        _startingBodyColor = _spriteRenderer.color;
        _spriteRenderer.color = _hunterBodyColor;
    }

    public void Exit()
    {
        _spriteRenderer.color = _startingBodyColor;
    }

    public void FixedTick()
    {
        _attacker.Attacking();
        _enemyMovement.FollowForTarget();
    }

    public void Tick()
    {
        //throw new System.NotImplementedException();
    }
}
