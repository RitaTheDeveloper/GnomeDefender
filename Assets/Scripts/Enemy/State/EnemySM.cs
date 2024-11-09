using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySM : StateMachine
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public HunterEnemyState HunterState { get; private set; } 
    public PatrolEnemyState PatrolState { get; private set; }
    private IAttacker _attacker;
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _attacker = GetComponent<IAttacker>();
        _enemyMovement = GetComponent<EnemyMovement>();
        HunterState = new HunterEnemyState(_spriteRenderer, _attacker, _enemyMovement);
        PatrolState = new PatrolEnemyState(_spriteRenderer, _enemyMovement);
    }

    private void Start()
    {
        ChangeState(PatrolState);
    }

}
