using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private EnemyController _enemyController;

    private void OnEnable()
    {
        _enemyController.OnAttack += DisplayAttack;
    }

    private void OnDisable()
    {
        _enemyController.OnAttack -= DisplayAttack;
    }

    private void Update()
    {
        UpdateMotionDisplay();
    }

    private void UpdateMotionDisplay()
    {
        var moveHorizontal = _enemyMovement.Direction.x;

        if (moveHorizontal > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (moveHorizontal < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void DisplayAttack()
    {
        _animator.SetTrigger("Attack");
    }

}
