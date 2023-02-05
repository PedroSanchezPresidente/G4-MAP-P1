using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillKoopa : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce;
    private void Start()
    {
        this.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")//evalua si choca con mario
        {
            other.GetComponent<Rigidbody2D>().velocity = Vector2.up * _jumpForce;
            gameObject.GetComponent<KoopaComponent>().ShellDeath();
        }
    }
}
