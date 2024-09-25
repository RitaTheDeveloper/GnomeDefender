using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Unit
{
    [SerializeField] private TargetTypeAndDetectionRadius[] targets;
    //private GameObject _currentTarget = null;
    private EnemyMovement _enemyMovement;
    GameObject _targetPlayer, _targetTown;

    protected override void Start()
    {
        _targetPlayer = _spawnerController.GetTarget(TargetForEnemyType.Player);
        _targetTown = _spawnerController.GetTarget(TargetForEnemyType.Town);
        DefineTarget();
        _enemyMovement = GetComponent<EnemyMovement>();
        if (_target)
        {
            _enemyMovement.SetTarget(_target);
            SetTarget(_target);
        }
        base.Start();
    }
    private void Update()
    {
        DefineTarget();
        _enemyMovement.SetTarget(_target);
    }

    public override void Attacking()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer > _unitParameters.Cd && _target && Vector2.Distance(transform.position, _target.transform.position) < _unitParameters.AttackRange)
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
        if (_targetPlayer && Vector2.Distance(transform.position, _targetPlayer.transform.position) <= targets[0].detectionRadius)
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
}
