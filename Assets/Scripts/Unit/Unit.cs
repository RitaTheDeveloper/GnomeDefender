using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IAttacker
{
    [SerializeField] protected Ability[] _abilitys;
    [SerializeField] protected TargetType _targetType;
    [SerializeField] protected LayerMask _layerMask;
    protected float _timer = 0f;
    protected UnitParameters _unitParameters;
    public GameObject Target { get; protected set; } = null;
    protected SpawnerController _spawnerController;

    protected virtual void Awake()
    {
        _unitParameters = GetComponent<UnitParameters>();
    }

    protected virtual void FixedUpdate()
    {
        if (_abilitys.Length > 0)
        {
            Attacking();
        }

    }
    
    public void Init(SpawnerController spawnerController)
    {
        _spawnerController = spawnerController;
    }

    protected virtual void UseAbility(IDamageable target, int index = 0)
    {
        Ability UsedAbility = _abilitys[index];
        UsedAbility.Execute(this, target, _layerMask);
    }

    public virtual void Attacking()
    {
        _timer += Time.fixedDeltaTime;
        FindObject findObject = new FindObject();
        Target = findObject.FindTarget(_targetType, this.transform.position, _unitParameters.CurrentAttackRange, _layerMask);

        if (Target && _timer >= 1f / _unitParameters.CurrentAttackSpeed)// && Vector2.Distance(transform.position, _target.transform.position) < _unitParameters.AttackRange)
            Attack();
    }

    public virtual void Attack()
    {
        _timer = 0f;   
        if (Target != null)
        {
            UseAbility(Target.GetComponent<IDamageable>(), 0);
        }        
    }

    public virtual float GetDamage()
    {
        return _unitParameters.CurrentDamage;
    }

    public void SetTarget(GameObject target)
    {
        Target = target;
    }
}
