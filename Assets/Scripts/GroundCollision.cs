using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    private MovementComponent _movementComponent;
    // Start is called before the first frame update
    void Start()
    {
        _movementComponent = FindObjectOfType<MovementComponent>();
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        _movementComponent._onGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _movementComponent._onGround = false;
    }
}
