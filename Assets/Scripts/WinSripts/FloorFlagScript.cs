using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFlagScript : MonoBehaviour
{
    [SerializeField]
    private WinAnimations _player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player.toCastle();
    }
}
