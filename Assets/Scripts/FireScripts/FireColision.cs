using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireColision : MonoBehaviour
{
    [SerializeField] GameObject _fireBall;
    private Rigidbody2D _rbFireBall;

    public bool right;
    private void Start()
    { 
        _rbFireBall = _fireBall.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        // arregla un bug que a veces a la bola de fuego le da por darse la vuelta
        if ((right && _rbFireBall.velocity.x < 0) || (!right && _rbFireBall.velocity.x > 0))
        {
            _rbFireBall.velocity = -_rbFireBall.velocity;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(_fireBall);
    }
}
