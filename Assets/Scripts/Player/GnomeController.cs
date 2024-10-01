using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeController : Unit, IMoveable
{
    GnomeSM _gnomeSM;
    [field: SerializeField] public float Speed { get; set; } = 5f;
    public Rigidbody2D RB { get; set; }


    protected override void Awake()
    {
        base.Awake();
        RB = GetComponent<Rigidbody2D>();
        _gnomeSM = GetComponent<GnomeSM>();
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
}
