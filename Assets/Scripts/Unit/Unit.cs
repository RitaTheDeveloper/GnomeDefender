using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IAttacker
{
    [SerializeField] protected Ability[] _abilitys;
    [SerializeField] protected TargetType _targetType;
    private float _timer = 0f;
    private UnitParameters _unitParameters;
    private GameObject _target = null;

    private void Start()
    {
        _unitParameters = GetComponent<UnitParameters>();
    }

    private void FixedUpdate()
    {
        if (_abilitys.Length > 0)
        {
            Attacking();
        }
      
    }

    protected virtual void UseAbility(IDamageable target, int index = 0)
    {
        Ability UsedAbility = _abilitys[index];
        UsedAbility.Execute(this, target);
    }

    protected void Attacking()
    {
        _timer += Time.fixedDeltaTime;
        FindObject findObject = new FindObject();
        _target = findObject.FindTarget(_targetType, this.transform.position, _unitParameters.AttackRange, LayerMask.GetMask("Enemy"));

        if (_timer > _unitParameters.Cd && _target)// && Vector2.Distance(transform.position, _target.transform.position) < _unitParameters.AttackRange)
            Attack();
    }

    public void Attack()
    {
        _timer = 0f;        
        UseAbility(_target.GetComponent<IDamageable>(), 0);
    }

    public float GetDamage()
    {
        throw new System.NotImplementedException();
    }
}
