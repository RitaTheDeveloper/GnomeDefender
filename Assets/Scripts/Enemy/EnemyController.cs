using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Unit
{
    [SerializeField] private TargetTypeAndDetectionRadius[] targets;
    //private GameObject _currentTarget = null;
    private EnemyMovement _enemyMovement;
    GameObject target1, target2;

    protected override void Start()
    {
        DefineTheTarget dt = new DefineTheTarget();
        target1 = dt.FindTargetAtScene(TargetForEnemyType.Player);
        target2 = dt.FindTargetAtScene(TargetForEnemyType.Town);
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
        if (Vector2.Distance(transform.position, target1.transform.position) <= targets[0].detectionRadius)
        {
            _target = target1;
        }
        else if (Vector2.Distance(transform.position, target2.transform.position) <= targets[1].detectionRadius)
        {
            _target = target2;
        }
        else
        {
            _target = null;
        }
    }
}
