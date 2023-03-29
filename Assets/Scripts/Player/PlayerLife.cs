using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Action OnPlayerDeath;
    private Rigidbody2D _rigidbody;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsFallenDown())
            RestartLevel();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
            RestartLevel();
    }

    private void RestartLevel()
    {
        OnPlayerDeath?.Invoke();
    }

    private bool IsFallenDown()
    {
        float downLine = -15;
        return _rigidbody.position.y < downLine ? true : false;
    }
}
