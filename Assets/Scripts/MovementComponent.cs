using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _jumpForce;
    public bool _onGround;
    [HideInInspector]
    public bool blockHitted = false;

    private Animator animator;

    #region Methods
    public void Left()
    {
        if (_rigidbody2D.velocity.x > -_maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.left * _speed , ForceMode2D.Force);
            animator.SetFloat("Horizontal", Mathf.Abs(_rigidbody2D.velocity.x));
        }
    }
    public void Right()
    {
        if (_rigidbody2D.velocity.x < _maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.right * _speed, ForceMode2D.Force);
            animator.SetFloat("Horizontal", Mathf.Abs(_rigidbody2D.velocity.x));
        }
    }
    public void Sprint() 
    {
        if (_onGround)
        {
            _maxSpeed = 7;
        }
        else _maxSpeed = 5;
    }

    public void Walk()
    {
        _maxSpeed = 5;
    }

    public void Jump()
    {
        if (_onGround)
        {
            _rigidbody2D.velocity *=Vector2.right;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _onGround = false;
        }
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _onGround = true;
        _maxSpeed = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if(_rigidbody2D.velocity.x < 0.1 && _rigidbody2D.velocity.x > -0.1)
        {
            animator.SetFloat("Horizontal", _rigidbody2D.velocity.x);
        }
    }
    private void FixedUpdate()
    {
        /*else if (_fall)
        {
            _rigidbody2D.AddForce(Vector2.down * _downForce);
        }*/
        animator.SetBool("onGround", _onGround);

    }


}
