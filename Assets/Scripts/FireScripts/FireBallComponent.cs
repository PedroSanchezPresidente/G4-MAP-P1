using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallComponent : MonoBehaviour
{
    [SerializeField] float _bounciness;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _bounciness);
        }
    }
}
