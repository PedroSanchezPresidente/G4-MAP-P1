using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision != null)
        {
            if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Foot")
            {
                PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.MUERTO);
            }
            else Destroy(collision.gameObject);
        }
    }
}

