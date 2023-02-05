using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goombaComponent : MonoBehaviour
{
    public int speed;
    
    private bool sentido; // si el sentido es false el goomba se mueve a la izquierda, pero si esta en true se mueve a la derecha
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (speed < 0)
        {
            sentido = false;
        }
    }

    // Update is called once per frame
    void Update() // cambia el sentido del goomba en funcion del estado de la variable bool sentido
    {
        if(sentido)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Cambia?");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bloques"))
        {
            Debug.Log("Cambia");
            if (sentido)
            {
                sentido = false;
            }
            else
            {
                sentido = true;
            }
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("ScreenLimits"))
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
