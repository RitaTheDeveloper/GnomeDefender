using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyState : IState
{
    private SpriteRenderer _spriteRenderer;
    private EnemyMovement _enemyMovement;

    Color _patrolBodyColor = Color.white;
    Color _startingBodyColor;

    public PatrolEnemyState(SpriteRenderer spriteRenderer, EnemyMovement enemyMovement)
    {
        _spriteRenderer = spriteRenderer;
        _enemyMovement = enemyMovement;
    }

    public void Enter()
    {
        _startingBodyColor = _spriteRenderer.color;
        _spriteRenderer.color = _patrolBodyColor;
    }

    public void Exit()
    {
        _spriteRenderer.color = _startingBodyColor;
    }

    public void FixedTick()
    {
        _enemyMovement.Patrol();
    }

    public void Tick()
    {

    }
}
