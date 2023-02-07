using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaRebote : MonoBehaviour
{
    [SerializeField] private KoopaComponent _koopaComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Cambia?");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bloques"))
        {
            Debug.Log("Cambia");
            if (_koopaComponent.sentido)
            {
                Debug.Log("derecha");
                _koopaComponent.sentido = false;
            }
            else
            {
                Debug.Log("izquierda");
                _koopaComponent.sentido = true;
            }
        }
    }
}
