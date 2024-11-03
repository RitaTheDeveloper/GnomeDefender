using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GnomeController _gnomeController;

    private Rigidbody2D _rb;

    private void OnEnable()
    {
        _gnomeController.OnAttack += DisplayAttack;
    }

    private void OnDisable()
    {
        _gnomeController.OnAttack -= DisplayAttack;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateAnimOfMove();
        UpdateMotionDisplay();
    }

    private void UpdateMotionDisplay()
    {
        var moveHorizontal = _gnomeController.Direction.x;

        if (moveHorizontal > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (moveHorizontal < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void UpdateAnimOfMove()
    {
        var velocity = Mathf.Abs(_rb.velocity.x) + Mathf.Abs(_rb.velocity.y);
        _animator.SetFloat("velocityX", velocity);
    }

    private void DisplayAttack()
    {
        _animator.SetTrigger("Hit");
    }
}
