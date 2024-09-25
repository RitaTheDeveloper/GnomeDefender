using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        UpdateAnim();

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        _rb.velocity = _rb.velocity = new Vector2(moveHorizontal * _speed, moveVertical * _speed);

        if (moveHorizontal > 0.01f)
            _spriteRenderer.flipX = false;
        else if (moveHorizontal < -0.01f)
            _spriteRenderer.flipX = true;       
    }

    private void UpdateAnim()
    {
        _animator.SetFloat("velocityX", Mathf.Abs(_rb.velocity.x));
    }

    private void Attack()
    {
        _animator.SetTrigger("Hit");
    }


}
