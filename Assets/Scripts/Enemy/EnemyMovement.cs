using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _patrolRadius;

    Collider2D myCol;
    Collider2D targetCol;
    private float _speed;

    GameObject target;
    public Vector2 Direction { get; private set; }    
    public bool StopMove { get; set; }

    private Vector2[] _pointsForPatrol = new Vector2[2];
    private int _currentWaypointIndex;

    private void Awake()
    {
        myCol = GetComponent<Collider2D>();
        
    }

    private void Start()
    {
        _pointsForPatrol[0] = transform.position;
        _pointsForPatrol[1] = GetPointOfPatrol();

        _speed = _moveSpeed;
        StopMove = false;

        if (target)
        {
            targetCol = target.gameObject.GetComponent<Collider2D>();
        }
    }


    public void FollowForTarget()
    {
        if (target)
        {
            targetCol = target.gameObject.GetComponent<Collider2D>();
        }

        if (target != null && !StopMove)
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
        else
        {
            Direction = _pointsForPatrol[_currentWaypointIndex] - (Vector2)transform.position;
            Direction.Normalize();
        }
        
    }


    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void Patrol()
    {
        Vector2 wayPoint = _pointsForPatrol[_currentWaypointIndex];
        if (Vector2.Distance(transform.position, wayPoint) < 0.01f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _pointsForPatrol.Length;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, _speed * Time.deltaTime);
        }

        RotateTowardsTarget();
    }

    private Vector2 GetPointOfPatrol()
    {
        return (Vector2)transform.position + Random.insideUnitCircle.normalized * _patrolRadius;
    }
    
}
