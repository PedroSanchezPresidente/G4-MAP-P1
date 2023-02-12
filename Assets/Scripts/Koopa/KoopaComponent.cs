using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaComponent : MonoBehaviour
{
    #region parameters
    public int speed;
    public bool sentido; // si el sentido es false el goomba se mueve a la izquierda, pero si esta en true se mueve a la derecha
    #endregion

    #region references
    [SerializeField]
    private GameObject _caparazon; // referencia al caparazon del koopa a spawnear
    [SerializeField]
    private Transform _shellSpawn;
    private Animator _animator;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update() // cambia el sentido del goomba en funcion del estado de la variable bool sentido
    {
        if (sentido)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
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
        _animator.SetBool("killed", true);
        Destroy(gameObject);
    }
    public void ShellDeath()
    {
        //instancia el caparazon justo antes de morir
        Instantiate(_caparazon, _shellSpawn.position, Quaternion.identity);
        _animator.SetBool("killed", true);
        Destroy(gameObject);
    }
}