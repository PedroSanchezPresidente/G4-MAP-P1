using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerComponent : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")//evalua si choca con mario
        {
            //PlayerManager.Instance.NextState = PlayerStates.MUERTO
            Debug.Log("next");

        }
    }
}
