using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Unit
{
    [SerializeField] private GameObject _currentTarget = null;
    private EnemyMovement _enemyMovement;

    protected override void Start()
    {
        _currentTarget = GameObject.FindGameObjectWithTag("Town");
        _enemyMovement = GetComponent<EnemyMovement>();
        if (_currentTarget)
        {
            _enemyMovement.SetTarget(_currentTarget.transform);
            SetTarget(_currentTarget);
        }
        base.Start();
    }

    public override void Attacking()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer > _unitParameters.Cd && _target && Vector2.Distance(transform.position, _target.transform.position) < _unitParameters.AttackRange)
        {
            Attack();
            _enemyMovement.StopMove = true;
        }
    }
}
