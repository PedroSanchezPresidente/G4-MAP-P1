using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goombaComponent : MonoBehaviour
{
    [SerializeField]
    private SoundManager _soundManager;
    public int speed;
    
    public bool sentido; // si el sentido es false el goomba se mueve a la izquierda, pero si esta en true se mueve a la derecha
    
    
    // Start is called before the first frame update
    void Start()
    {
        _soundManager = SoundManager.Instance;
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

        if (collision.gameObject.layer == LayerMask.NameToLayer("ScreenLimits"))
        {
            Death();
        }
    }

    public void Death()
    {
        _soundManager.AudioSelection(14, 0.4f);
        Destroy(gameObject);
    }
}
