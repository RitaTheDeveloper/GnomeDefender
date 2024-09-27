using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeController : MonoBehaviour, IMoveable
{
    [field: SerializeField] public float Speed { get; set; } = 5f;
    public Rigidbody2D RB { get; set; }


    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
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
