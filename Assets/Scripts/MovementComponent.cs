using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed;
    private float _maxSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _downForce;
    public bool _onGround;
    [HideInInspector]
    public bool blockHitted = false;
    private bool _jump;
    private bool _fall;

    private Animator animator;

    #region Methods
    public void Left()
    {
        if (_rigidbody2D.velocity.x > -_maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.left * _speed , ForceMode2D.Force);
            animator.SetFloat("Horizontal", Mathf.Abs(Vector2.left.x * _speed));
        }
    }
    public void Right()
    {
        if (_rigidbody2D.velocity.x < _maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.right * _speed, ForceMode2D.Force);
            animator.SetFloat("Horizontal", Mathf.Abs(Vector2.left.x * _speed));
        }
    }
    public void Sprint() 
    {
        if (_onGround)
        {
            _maxSpeed = 12;
        }
        else _maxSpeed = 10;
    }
    public void Jump()
    {
        if (_onGround)
        {
            _jump = true;
            _fall = false;
            _onGround = false;
        }
    }
    public void Down()
    {
        //hacer que se agache
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
        if (!Input.GetKey(KeyCode.Space))
        {
            _fall = true;
        }
    }
    private void FixedUpdate()
    {
        if (_jump)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _jump = false;

        }
        else if (_fall)
        {
            _rigidbody2D.AddForce(Vector2.down * _downForce);
        }
        animator.SetBool("onGround", _onGround);

    }


}
