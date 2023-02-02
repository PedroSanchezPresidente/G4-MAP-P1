using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private int _fpsLimit = 60;//Para no petar el PC un saludo
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _downforce;//Se activa al dejar de presionar       
    [HideInInspector]
    public bool _onGround;
    [HideInInspector]
    public bool blockHitted = false;  //Limitacion de bloques golpeados por salto

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
        _maxSpeed = 7;
    }
    public void StopSprint()
    {
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


}
