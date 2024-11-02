using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    Collider2D myCol;
    Collider2D targetCol;
    private float _speed;
    private bool _stopMove;

    GameObject target;
    public Vector2 Direction { get; private set; }
    private EnemyController enemycontroller;

    public bool StopMove { get => _stopMove; set => _stopMove = value; }

    private void Awake()
    {
        myCol = GetComponent<Collider2D>();
       // enemycontroller.GetComponent<EnemyController>();
    }

    private void Start()
    {
        _speed = _moveSpeed;
        _stopMove = false;

        if (target)
        {
            targetCol = target.gameObject.GetComponent<Collider2D>();
        }
    }

    private void FixedUpdate()
    {

        if (target)
        {
            targetCol = target.gameObject.GetComponent<Collider2D>();
        }

        if (target != null && !_stopMove)
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
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
        }
            
    }

    private void RotateTowardsTarget()
    {
        if (target)
        {
            Direction = target.transform.position - transform.position;
            Direction.Normalize();
            //Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, Direction);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
        
    }


    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    
}
