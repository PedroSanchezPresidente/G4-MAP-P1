using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireColision : MonoBehaviour
{
    [SerializeField] GameObject _fireBall;
    [SerializeField] GameObject _explosion;
    private Rigidbody2D _rbFireBall;

    public bool right;
    private float speed;
    private void Start()
    { 
        _rbFireBall = _fireBall.GetComponent<Rigidbody2D>();
        speed = GameObject.Find("Player").GetComponent<FireMarioComponent>()._speed;
    }
    private void FixedUpdate()
    {
        // arregla un bug que a veces a la bola de fuego le da por darse la vuelta
        if ((right && _rbFireBall.velocity.x < 0) || (!right && _rbFireBall.velocity.x > 0))
        {
            _rbFireBall.velocity = -_rbFireBall.velocity;
        }
        if (right)
            _rbFireBall.velocity = new Vector2(speed, _rbFireBall.velocity.y);
        else
            _rbFireBall.velocity = new Vector2(-speed, _rbFireBall.velocity.y);
        

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 9)
        {
            GameObject explosion = Instantiate(_explosion);
            explosion.transform.position = transform.position;
            Destroy(_fireBall);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.layer == 10)
        {
            GameObject explosion = Instantiate(_explosion);
            explosion.transform.position = transform.position;
            Destroy(_fireBall);
        }
    }
}
