using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    float Speed { get; set; }
    Rigidbody2D RB { get; set; }
    void Move();
}
