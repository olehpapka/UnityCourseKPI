using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private enum PlayerState { idle, running, jumping, falling};


    public void UpdatePlayerState(float direction)
    {
        PlayerState state;
        if (direction != 0f)
            state = PlayerState.running;
        else
            state = PlayerState.idle;

        if (_rigidbody.velocity.y > .1f)
            state = PlayerState.jumping;
        else if (_rigidbody.velocity.y < -.1f)
            state = PlayerState.falling;
        _animator.SetInteger("state", (int)state);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    
    
}
