using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player 
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private bool _faceRight;
        [SerializeField] private float _jumpHeight;

        private Rigidbody2D _rigidbody;
        

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

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
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

