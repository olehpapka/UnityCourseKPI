using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerEntity : MonoBehaviour, IDisposable
{

    [SerializeField] private DirectionalMovementData _directionalMovementData;
    [SerializeField] private JumpData _jumpData;

    [SerializeField] private LayerMask _jumpableGround;

    [SerializeField] private GameObject _spawnPoint;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    private AnimationController _animationController;


    private DirectionalMover _directionalMover;
    private Jumper _jumper;
    private PlayerLife _playerLife;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _animationController = GetComponent<AnimationController>();
        _directionalMover = new DirectionalMover(_rigidbody, _directionalMovementData);
        _jumper = new Jumper(_rigidbody, _jumpData);
        _playerLife = GetComponent<PlayerLife>();
        _playerLife.OnPlayerDeath += OnPlayerDeath;
    }

    private void Update()
    {
        _animationController.UpdatePlayerState(_directionalMover.Direction);
    }



    public void MoveHorizontally(float direction) => _directionalMover.MoveHorizontally(direction);




    public void Jump()
    {
        if (!IsGrounded())
            return;
        _jumper.Jump();
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f,
            Vector2.down, 0.1f, _jumpableGround);
    }

    public void OnPlayerDeath()
    {
        transform.position = _spawnPoint.transform.position;
    }

    public void Dispose()
    {
        _playerLife.OnPlayerDeath -= OnPlayerDeath;
    }

}

