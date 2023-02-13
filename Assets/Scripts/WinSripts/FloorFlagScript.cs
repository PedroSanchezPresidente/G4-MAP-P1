using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFlagScript : MonoBehaviour
{
    [SerializeField]
    private WinAnimations _player;
    private SoundManager _soundManager;
    private void Start()
    {
        _soundManager = SoundManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player.gameObject.GetComponent<MovementComponent>().GroundedAnim();
        _soundManager.AudioSelection(16, 0.5f);
        _player.toCastle();
    }
}
