using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Tilemaps;
using UnityEngine;

public class KillPlayerComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")//evalua si choca con mario
        {
            switch (PlayerManager.Instance.CurrentState)
            {
                case PlayerManager.PlayerStates.PEQUEÑO:
                    PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.MUERTO);
                    
                    break;
                case PlayerManager.PlayerStates.GRANDE:
                    PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.PEQUEÑO);
                    break;
                case PlayerManager.PlayerStates.FUEGO:
                    PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.GRANDE);
                    break;
                case PlayerManager.PlayerStates.ESTRELLA:
                    break;
            }
            Debug.Log(PlayerManager.Instance.CurrentState);
        }
    }
}
