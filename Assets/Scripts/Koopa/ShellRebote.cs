using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellRebote : MonoBehaviour
{
    [SerializeField] private ShellComponent _shellComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bloques"))
        {
            if (_shellComponent.sentido)
            {
                _shellComponent.sentido = false;
            }
            else
            {
                _shellComponent.sentido = true;
            }
        }
    }
}
