using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : IMovable
{
    private Rigidbody2D rb;
    private float speed;

    public HorizontalMover(Rigidbody2D rb, float speed)
    {
        this.rb = rb;
        this.speed = speed;
    }

    public void Move(float direction)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
}
