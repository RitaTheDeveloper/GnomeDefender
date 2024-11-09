using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : Unit
{
    public Action OnAttack;

    [SerializeField] private TargetTypeAndDetectionRadius[] targets;
    //private GameObject _currentTarget = null;
    private EnemyMovement _enemyMovement;
    private Health _enemyHealth;
    GameObject _targetPlayer, _targetTown;
    GnomeSM _playerSM;
    EnemySM _enemySM;

    protected override void Awake()
    {
        base.Awake();
        _enemyHealth = GetComponent<Health>();
        _enemySM = GetComponent<EnemySM>();
    }

    private void OnEnable()
    {
        _enemyHealth.onDead += Die;
    }

    private void OnDisable()
    {
        _enemyHealth.onDead += Die;
    }

    private void Start()
    {
        _targetPlayer = _spawnerController.GetTarget(TargetForEnemyType.Player);
        if (_targetPlayer)
            _playerSM = _targetPlayer.GetComponent<GnomeSM>();
        _targetTown = _spawnerController.GetTarget(TargetForEnemyType.Town);
        DefineTarget();
        _enemyMovement = GetComponent<EnemyMovement>();
        if (Target)
        {
            _enemyMovement.SetTarget(Target);
            SetTarget(Target);
        }
    }

    protected override void FixedUpdate()
    {
        //base.FixedUpdate();
    }

    private void Update()
    {
        DefineTarget();
        _enemyMovement.SetTarget(Target);
    }

    public override void Attacking()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer > 1f /_unitParameters.CurrentAttackSpeed && Target && Vector2.Distance(transform.position, Target.transform.position) < _unitParameters.CurrentAttackRange)
        {
            Attack();
            _enemyMovement.StopMove = true;
        }
        else
        {
            _enemyMovement.StopMove = false;
        }
    }

    public void DefineTarget()
    {
        if (_targetPlayer  && _playerSM.CurrentState == _playerSM.KillerState && Vector2.Distance(transform.position, _targetPlayer.transform.position) <= targets[0].detectionRadius)
        {
            Target = _targetPlayer;
            _enemySM.ChangeState(_enemySM.HunterState);
        }
        else if (_targetTown && Vector2.Distance(transform.position, _targetTown.transform.position) <= targets[1].detectionRadius)
        {
            Target = _targetTown;
            _enemySM.ChangeState(_enemySM.HunterState);
        }
        else
        {
            Target = null;
            _enemySM.ChangeState(_enemySM.PatrolState);
        }
    }

    private void Die()
    {
        Actions.OnEnemyKilled(_unitParameters.ExpForKill);
    }

    public override void Attack()
    {
        OnAttack.Invoke();
        base.Attack();
    }
}
