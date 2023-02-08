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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2"))
        {
            _movementComponent.Jump();
        }
       

        // Sistema de movimiento
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("DPadY") > 0 || Input.GetAxis("Horizontal") > 0)
        {
            _movementComponent.Right();

        }
        if (Input.GetKey(KeyCode.A) || Input.GetAxis("DPadX") < 0 || Input.GetAxis("Horizontal") < 0)
        {
            _movementComponent.Left();

        }

        // Sitema de correr y disparar
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("Circle"))
        {
            _movementComponent.Sprint();
            _fireMarioComponent.Fire();
        }
        // Devuelve la velocidad normal cuando se suelta el boton
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetButtonUp("Circle"))
        {
            _movementComponent.StopSprint();
        }
    }
}
