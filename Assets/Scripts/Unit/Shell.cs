using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private LayerMask _collisionMask;
    private Vector2 _direction;
    private float _damage;
    private Vector2 _target;
    private GameObject target;
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        CheckCollsion(5f * Time.deltaTime);

        transform.Translate(_direction * Time.deltaTime * _speed);
    }

    public void Init(Vector2 direction, float damage, LayerMask collisionMask)
    {
        _direction = direction;
        _damage = damage;
        _collisionMask = collisionMask;
    }

    private void CheckCollsion(float moveDistance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, moveDistance, _collisionMask);
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
}
