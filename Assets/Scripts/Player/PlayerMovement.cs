using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player 
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerMovement : MonoBehaviour
    {
        [Header("HorizontalMovement")]
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private bool _faceRight;

        [Header("Jump")]
        [SerializeField] private float _jumpHeight;

        [SerializeField] private LayerMask _jumpableGround;
        private Rigidbody2D _rigidbody;
        private BoxCollider2D _collider;
        
        

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider= GetComponent<BoxCollider2D>();
        }

        public void MoveHorizontally(float direction)
        {
            SetDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _horizontalSpeed;
            _rigidbody.velocity = velocity;
        }

        public void Jump()
        {
            Vector2 velocity = _rigidbody.velocity;
            velocity.y = _jumpHeight;
            _rigidbody.velocity = velocity;
        }

        public bool IsGrounded()
        {
            return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f,
                Vector2.down, 0.1f, _jumpableGround);
        }

        private void SetDirection(float direction)
        {
            if ((_faceRight && direction < 0) ||
                (!_faceRight && direction > 0))
                Flip();
        }

        private void Flip()
        {
            transform.Rotate(0, 180, 0);
            _faceRight = !_faceRight;
        }

        
    }
}

