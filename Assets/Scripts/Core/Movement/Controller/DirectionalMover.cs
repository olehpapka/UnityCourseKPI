using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DirectionalMover
{
    private readonly Rigidbody2D _rigidbody;
    private readonly Transform _transform;
    private readonly DirectionalMovementData _directionalMovementData;

    private Vector2 _movement;
    private Direction _direction;
    public bool IsMoving => _movement.magnitude > 0;
    public float Direction => _movement.x;
    public bool FacingRight { get; private set; }

    public DirectionalMover(Rigidbody2D rigidbody, DirectionalMovementData directionalMovementData)
    {
        _rigidbody = rigidbody;
        _transform = _rigidbody.transform;
        _directionalMovementData = directionalMovementData;
    }

    public void MoveHorizontally(float direction)
    {
        _movement.x = direction;
        SetDirection(direction);
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = direction * _directionalMovementData.HorizontalSpeed;
        _rigidbody.velocity = velocity;
    }
    private void SetDirection(float direction)
    {
        if ((_directionalMovementData.FaceRight && direction < 0) ||
            (!_directionalMovementData.FaceRight && direction > 0))
            Flip();
    }

    private void Flip()
    {
        _rigidbody.transform.Rotate(0, 180, 0);
        _directionalMovementData.Flip();               
    }
}
