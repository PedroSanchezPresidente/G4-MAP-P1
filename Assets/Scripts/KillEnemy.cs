using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )//evalua si choca con mario
        {
            other.GetComponent<Rigidbody2D>().velocity = Vector2.up * _jumpForce;

            if (gameObject.tag == "Goomba") //si choca con bola de fuego
            {
                GameManager.Instance.Experience(100);
                gameObject.GetComponent<goombaComponent>().Death();
            }
            else if (gameObject.tag == "Koopa" )
            {
                GameManager.Instance.Experience(200);
                gameObject.GetComponent<KoopaComponent>().ShellDeath();
            }
        }
       
    }
}
