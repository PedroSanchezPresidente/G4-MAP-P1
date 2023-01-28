using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuestionBlock : MonoBehaviour
{
    [SerializeField]
    private BlockComponent _blockComponent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MovementComponent movementComponent = collision.gameObject.GetComponent<MovementComponent>();
        if (!movementComponent._blockHitted)
        {
            movementComponent._blockHitted = true;
            _blockComponent.onHit();
        }
    }
}
