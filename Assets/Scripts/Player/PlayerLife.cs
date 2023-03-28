using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsFallenDown())
        {
            Die();
            RestartLevel();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            RestartLevel();
        }
    }

    private void Die()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool IsFallenDown()
    {
        float downLine = -15;
        return _rigidbody.position.y < downLine ? true : false;
    }
}
