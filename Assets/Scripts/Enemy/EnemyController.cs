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

    protected override void Awake()
    {
        base.Awake();
        _enemyHealth = GetComponent<Health>();     
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
        if (_target)
        {
            _enemyMovement.SetTarget(_target);
            SetTarget(_target);
        }
    }

    private void Update()
    {
        DefineTarget();
        _enemyMovement.SetTarget(_target);
    }

    public override void Attacking()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer > 1f /_unitParameters.CurrentAttackSpeed && _target && Vector2.Distance(transform.position, _target.transform.position) < _unitParameters.CurrentAttackRange)
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
            _target = _targetPlayer;
        }
        else if (_targetTown && Vector2.Distance(transform.position, _targetTown.transform.position) <= targets[1].detectionRadius)
        {
            _target = _targetTown;
        }
        else
        {
            _target = null;
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
