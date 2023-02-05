using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerShellComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") //evalua si choca con mario
        {
            PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.MUERTO);
        }
        else if (other.gameObject.tag == "Goomba")
        {
            other.GetComponent<goombaComponent>().Death();
        }
        else if (other.gameObject.tag == "Koopa")
        {
            other.GetComponent<KoopaComponent>().SimpleDeath();
        }
    }
}
