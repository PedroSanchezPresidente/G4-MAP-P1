using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFlagScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<WinAnimations>().toCastle();
    }
}
