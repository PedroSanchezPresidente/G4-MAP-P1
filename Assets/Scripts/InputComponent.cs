using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region references
    private MovementComponent _movementComponent;
    #endregion

    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;
    private bool isJumping;

    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _movementComponent._onGround)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            _movementComponent.StarJumping();
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                _movementComponent.Jump();
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _movementComponent.Right();

        }
        if (Input.GetKey(KeyCode.A))
        {
            _movementComponent.Left();

        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _movementComponent.Sprint();
        }
        // Devuelve la velocidad normal cuando se suelta el boton
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _movementComponent.Walk();
        }
    }
}
