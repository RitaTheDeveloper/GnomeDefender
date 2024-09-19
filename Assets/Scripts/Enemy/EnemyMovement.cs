using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private Transform _target;

    Collider2D myCol;
    Collider2D targetCol;
    private float _speed;
    private bool _stopMove;

    public bool StopMove { get => _stopMove; set => _stopMove = value; }

    private void Awake()
    {
        myCol = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _speed = _moveSpeed;
        _stopMove = false;

        if (_target)
        {
            targetCol = _target.gameObject.GetComponent<Collider2D>();
        }
    }

    private void FixedUpdate()
    { 
        if (_target != null && !_stopMove)
        {
            ColliderDistance2D distance = myCol.Distance(targetCol);
            if (!distance.isOverlapped)
            {
                MoveTowardsTarget();
                RotateTowardsTarget();
            }
        }
                
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        Vector2 direction = _target.position - transform.position;
        direction.Normalize();
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
}
