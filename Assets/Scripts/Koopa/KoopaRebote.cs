using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaRebote : MonoBehaviour
{
    [SerializeField] private KoopaComponent _koopaComponent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bloques") || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Cambia");
            if (_koopaComponent.sentido)
            {
                _koopaComponent.sentido = false;
            }
            else
            {
                _koopaComponent.sentido = true;
            }
        }
    }
}
