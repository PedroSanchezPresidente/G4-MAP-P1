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
        if (!movementComponent.blockHitted && !_blockComponent.isActivated)
        {
            movementComponent.blockHitted = true;
            _blockComponent.onHit();
        }
    }
}
