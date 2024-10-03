using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeController : Unit, IMoveable
{
    GnomeSM _gnomeSM;
    [field: SerializeField] public float Speed { get; set; } = 5f;
    public Rigidbody2D RB { get; set; }
    private PlayerLevelController _levelController;
    private Health _health;

    protected override void Awake()
    {
        base.Awake();
        RB = GetComponent<Rigidbody2D>();
        _gnomeSM = GetComponent<GnomeSM>();
        _levelController = GetComponent<PlayerLevelController>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _levelController.onLevelUp += IncreaseParametersForLevelUp;
    }

    private void OnDisable()
    {
        _levelController.onLevelUp -= IncreaseParametersForLevelUp;

    }

    protected override void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {

    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(moveHorizontal, moveVertical);
        RB.MovePosition(RB.position + input * Speed * Time.fixedDeltaTime);
    }

    public void IncreaseParametersForLevelUp()
    {
        _unitParameters.CurrentMaxHealth += 10f;
        _unitParameters.CurrentDamage += 1f;
        _health.UpdateMaxHP();
    }
}
