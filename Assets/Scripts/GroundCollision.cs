using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    [SerializeField]
    private MovementComponent _movementComponent;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        _movementComponent.blockHitted = false;
        _movementComponent._onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
>>>>>>> d7853ba8bc218a1e0fa7ac85e45975070db9e7c6
    {
        _movementComponent._onGround = false;
    }
}
