using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellComponent : MonoBehaviour
{
    #region parameters
    public int speed;

    // si el sentido es false el goomba se mueve a la izquierda, pero si esta en true se mueve a la derecha
    public bool sentido;
    #endregion

    private Transform _transform;

    #region methods

    // movimiento del caparazon
    private void ShellMovement()
    {
        if (sentido)
        {
            _transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            _transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
    }


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ShellMovement();
    }
}

