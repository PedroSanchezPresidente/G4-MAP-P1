using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlowerComponent : MonoBehaviour
{
    private SoundManager _soundManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //layer del player
        {
            _soundManager.AudioSelection(3, 0.5f);
            PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.FUEGO);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _soundManager = SoundManager.Instance;
    }
}
