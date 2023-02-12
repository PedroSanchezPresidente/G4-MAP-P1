using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<InputComponent>().enabled = false;
        collision.gameObject.GetComponent<MovementComponent>().enabled = false;
        collision.gameObject.GetComponent<WinAnimations>().winDown();
    }
}
