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
        if (Input.GetKey(KeyCode.Space))
        {
            _movementComponent.Jump();

        }
        if (Input.GetKey(KeyCode.D))
        {
            _movementComponent.Right();

        }
        if (Input.GetKey(KeyCode.A))
        {
            _movementComponent.Left();

        }
        if (Input.GetKey(KeyCode.S))
        {
            _movementComponent.Down();

        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _movementComponent.Sprint();
        }
    }
}
