using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlowerComponent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //layer del player
        {
            PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.FUEGO);
            Destroy(gameObject);
        }
    }
}
