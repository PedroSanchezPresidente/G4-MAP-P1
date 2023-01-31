using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    [SerializeField]
    private MovementComponent _movementComponent;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _movementComponent.blockHitted = false;
        _movementComponent._onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _movementComponent._onGround = false;
    }
}
