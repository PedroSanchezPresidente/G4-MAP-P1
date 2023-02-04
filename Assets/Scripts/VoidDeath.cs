using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VoidDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other != null)
        {
            if(other.gameObject.tag == "Player")
            {
                PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.MUERTO);
            }
            else { Destroy(other.gameObject); }
        }
    }
}
