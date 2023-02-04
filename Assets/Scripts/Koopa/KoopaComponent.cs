using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaComponent : MonoBehaviour
{
    #region parameters
    public int speed;
    private bool sentido; // si el sentido es false el goomba se mueve a la izquierda, pero si esta en true se mueve a la derecha
    #endregion

    #region references
    [SerializeField]
    private GameObject _caparazon; // referencia al caparazon del koopa a spawnear
    #endregion

    // Update is called once per frame
    void Update() // cambia el sentido del goomba en funcion del estado de la variable bool sentido
    {
        if (sentido)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }

    }
    // Muere sin soltar caparazon
    public void SimpleDeath()
    {
        Destroy(gameObject);
    }
    //Muerte con caparazon
    public void DeathWithShell()
    {
        //instancia el caparazon justo antes de morir

        Destroy(gameObject);
        //contador que espera 1 segundo para instanciar el caparazón
        float temp = 1;
        while(temp > 0)
        {
            temp -= Time.deltaTime;
        }
        Instantiate(_caparazon, this.transform.position, Quaternion.identity);
        
    }
}
