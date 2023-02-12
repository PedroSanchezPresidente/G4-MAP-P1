using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellRebote : MonoBehaviour
{
    [SerializeField] private ShellComponent _shellComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Cambia?");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bloques"))
        {
            Debug.Log("Cambia");
            if (_shellComponent.sentido)
            {
                Debug.Log("derecha");
                _shellComponent.sentido = false;
            }
            else
            {
                Debug.Log("izquierda");
                _shellComponent.sentido = true;
            }
        }
    }
}