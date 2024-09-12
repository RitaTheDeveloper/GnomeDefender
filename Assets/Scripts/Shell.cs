using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] LayerMask collisionMask;
    private Vector2 _direction;
    private float _damage;
    private Vector2 _target;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollsion(5f * Time.deltaTime);

        transform.Translate(_direction * Time.deltaTime * 5f);
    }

    public void Init(Vector2 direction, float damage)
    {
        _direction = direction;
        _damage = damage;
    }

    private void CheckCollsion(float moveDistance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, moveDistance, collisionMask);
        if (hit)
        {
            OutHitObject(hit);
        }
    }

    private void OutHitObject(RaycastHit2D hit)
    {
        // First knock back then hit the object
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    //private void MoveToPos()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, _target, 1f);
    //}


}
