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
        // Sistema de salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movementComponent.Jump();
        }
       

        // Sistema de movimiento
        if (Input.GetKey(KeyCode.D))
        {
            _movementComponent.Right();

        }
        if (Input.GetKey(KeyCode.A))
        {
            _movementComponent.Left();

        }

        // Sitema de correr y disparar
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _movementComponent.Sprint();
        }
        // Devuelve la velocidad normal cuando se suelta el boton
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _movementComponent.StopSprint();
        }
    }
}
