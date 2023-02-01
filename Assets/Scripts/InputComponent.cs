using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region references
    private MovementComponent _movementComponent;
    #endregion


    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movementComponent.StarJumping();
        }
        if (Input.GetKey(KeyCode.Space) && _movementComponent)
        {
            _movementComponent.JumpLonger();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _movementComponent.StopJump();
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
