using System;
using UnityEngine;


public class Jumper
{
    private readonly JumpData _jumpData;
    private readonly Rigidbody2D _rigidbody;

    public Jumper( Rigidbody2D rigidbody, JumpData jumpData)
    {
        _jumpData = jumpData;
        _rigidbody = rigidbody;
    }

    public void Jump()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.y = _jumpData.JumpHeight;
        _rigidbody.velocity = velocity;
    }
}

