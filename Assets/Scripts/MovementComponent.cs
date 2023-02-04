using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Security.Cryptography.X509Certificates;
>>>>>>> d7853ba8bc218a1e0fa7ac85e45975070db9e7c6
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
<<<<<<< HEAD
    Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed;
=======
    private Rigidbody2D _rigidbody2D;
    private int _fpsLimit = 60; //Para no petar el PC un saludo
    [SerializeField]
    private float _speed;
    [SerializeField]
>>>>>>> d7853ba8bc218a1e0fa7ac85e45975070db9e7c6
    private float _maxSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
<<<<<<< HEAD
    private float _downForce;
    public bool _onGround;
    private bool _jump;
    private bool _fall;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _onGround = true;
        _maxSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {          
            if (_rigidbody2D.velocity.x >-_maxSpeed)
            {
                _rigidbody2D.AddForce(Vector2.left * _speed * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {         
            if (_rigidbody2D.velocity.x < _maxSpeed)
            {
                _rigidbody2D.AddForce(Vector2.right * _speed * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        if (_onGround && Input.GetKey(KeyCode.LeftControl))
        {
            _maxSpeed = 12;
        }
        else _maxSpeed = 10;
        
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _jump = true;
            _fall = false;
            _onGround = false;
        }
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
    }
    
=======
    private float _downforce; //Se activa al dejar de presionar       
    [HideInInspector]
    public bool _onGround;
    [HideInInspector]
    public bool _isRunning; //Se activa para correr
    [HideInInspector]
    public bool blockHitted = false; //Limitacion de bloques golpeados por salto

    private Animator animator;
    private SpriteRenderer _spriteRenderer;

    #region Methods
    public void Left()
    {
        if (_rigidbody2D.velocity.x > -_maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.left * _speed, ForceMode2D.Force);
            _spriteRenderer.flipX = true;
            animator.SetFloat("horizontal", Mathf.Abs(_rigidbody2D.velocity.x));
        }
    }
    public void Right()
    {
        if (_rigidbody2D.velocity.x < _maxSpeed)
        {
            _rigidbody2D.AddForce(Vector2.right * _speed, ForceMode2D.Force);
            _spriteRenderer.flipX = false;
            animator.SetFloat("horizontal", Mathf.Abs(_rigidbody2D.velocity.x));
        }
    }
    public void Sprint() 
    {
        _isRunning = true;
        animator.SetBool("keyPressed", _isRunning);
        _maxSpeed = 7;
    }
    public void StopSprint()
    {
        _isRunning = false;
        animator.SetBool("keyPressed", _isRunning);
        _maxSpeed = 5;
    } 

    //Impulso inicial del salto
    public void Jump()
    {
        if (_onGround)
        {           
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);           
        }
    }

   
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = _fpsLimit;//limitador, no quitar
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            animator.SetFloat("horizontal", _rigidbody2D.velocity.x);
        }
    }
    private void FixedUpdate()
    {
        animator.SetBool("onGround", _onGround);
        if (!Input.GetKey(KeyCode.Space) && !_onGround)//Salto a distintas alturas si mantienes, (bajada)
        {
            _rigidbody2D.AddForce(Vector2.down * _downforce, ForceMode2D.Impulse);
        }
    }

>>>>>>> d7853ba8bc218a1e0fa7ac85e45975070db9e7c6

}
