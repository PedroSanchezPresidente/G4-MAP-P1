using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField]
    private FlagScript _flagScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.Experience(1000);
        collision.gameObject.GetComponent<InputComponent>().enabled = false;
        collision.gameObject.GetComponent<MovementComponent>().enabled = false;
        collision.gameObject.GetComponent<WinAnimations>().winDown();
        _flagScript.winDown();
    }
}
