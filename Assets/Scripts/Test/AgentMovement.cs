using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private UnitParameters _unitParameters;

    Collider2D myCol;
    Collider2D targetCol;
   

    private void Start()
    {
        myCol = GetComponent<Collider2D>();
        targetCol = _target.gameObject.GetComponent<Collider2D>();

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _navMeshAgent.SetDestination(new Vector3(_target.position.x, _target.position.y, transform.position.z));
    }

    private void Update()
    {
        ColliderDistance2D distance = myCol.Distance(targetCol);
        if (distance.isOverlapped)
        {
            _navMeshAgent.speed = 0f;
        }
        else
        {
           // _navMeshAgent.speed 
        }
    }

}
