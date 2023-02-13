using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    #region references
    private MovementComponent _movementComponent;
    private FireMarioComponent _fireMarioComponent;
    #endregion


    void Start()
    {
        _movementComponent = GetComponent<MovementComponent>();
        _fireMarioComponent = GetComponent<FireMarioComponent>();
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            _movementComponent.Squat(true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _movementComponent.Squat(false);
        }

        // Sitema de correr y disparar
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _movementComponent.Sprint();
            _fireMarioComponent.Fire();
        }
        // Devuelve la velocidad normal cuando se suelta el boton
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _movementComponent.StopSprint();
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            _movementComponent.Right();
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            _movementComponent.Left();
        }
        
        if (Input.GetButtonDown("Fire2"))
        {
            _movementComponent.Jump();
        }

        if (Input.GetButtonDown("R2"))
        {
            _movementComponent.Sprint();
            _fireMarioComponent.Fire();
        }

        if (Input.GetButtonUp("R2"))
        {
            _movementComponent.StopSprint();
        }
    }
}
