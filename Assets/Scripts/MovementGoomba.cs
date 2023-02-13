using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGoomba : MonoBehaviour
{
    [SerializeField] private goombaComponent _goombaComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bloques") || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (_goombaComponent.sentido)
            {
                _goombaComponent.sentido = false;
            }
            else
            {
                _goombaComponent.sentido = true;
            }
        }
    }
}
