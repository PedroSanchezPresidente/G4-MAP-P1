using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goomba")
        {
            other.GetComponent<goombaComponent>().isInScene = true;
        }
        else if (other.tag == "Koopa")
        {
            other.GetComponent<KoopaComponent>().isInScene = true;
        }
    }
}
