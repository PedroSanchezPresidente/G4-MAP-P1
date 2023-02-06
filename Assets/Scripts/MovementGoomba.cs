using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGoomba : MonoBehaviour
{
    [SerializeField] private goombaComponent _goombaComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Cambia?");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bloques") || collision.gameObject.layer == 9)
        {
            Debug.Log("Cambia");
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
