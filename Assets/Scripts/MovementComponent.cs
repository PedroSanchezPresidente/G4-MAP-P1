using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed;
    private float _maxSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _downForce;
    public bool _onGround;
    private bool _jump;
    private bool _fall;
    private bool _moveCamera;   
    public bool MoveCamera {get{ return _moveCamera; }}

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _onGround = true;
        _moveCamera = false;
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
            _moveCamera = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {         
            if (_rigidbody2D.velocity.x < _maxSpeed)
            {
                _rigidbody2D.AddForce(Vector2.right * _speed * Time.deltaTime, ForceMode2D.Impulse);
            }
            _moveCamera = true;
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
    

}
