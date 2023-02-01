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
    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;
    public bool isJumping;

    [HideInInspector]
    public bool _onGround;
    [HideInInspector]
    public bool blockHitted = false;  //Limitacion de bloques golpeados por salto

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

    public void StarJumping()
    {
        if (_onGround)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Vector2 v = _rigidbody2D.velocity;
            v.y = _jumpForce;
            _rigidbody2D.velocity = v;
            _onGround = false;
        }
    }

    public void JumpLonger()
    {
        if (jumpTimeCounter > 0)
        {
            Debug.Log(Time.deltaTime);
            Vector2 v = _rigidbody2D.velocity;
            v.y = _jumpForce;
            _rigidbody2D.velocity = v;
            jumpTimeCounter -= 0.1f;
        }
        else
        {
            isJumping = false;
        }
    }

    public void StopJump()
    {
        isJumping = false;
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
        animator.SetBool("onGround", _onGround);
    }


}
