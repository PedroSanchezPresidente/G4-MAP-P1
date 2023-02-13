using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellActivate : MonoBehaviour
{
    [SerializeField] private ShellComponent _shellComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && this.name == "Derecha" && _shellComponent.speed == 0)
        {
            _shellComponent.sentido = false;
            _shellComponent.speed = 4;
        }
        else if (collision.name == "Player" && this.name == "Izquierda" && _shellComponent.speed == 0)
        {
            _shellComponent.sentido = true;
            _shellComponent.speed = 4;
        }
        else if (collision.name == "Player" && this.name == "Arriba" && _shellComponent.speed != 0)
        {
            _shellComponent.speed = 0;
        }

    }
}
