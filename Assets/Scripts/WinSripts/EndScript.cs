using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    private SoundManager _soundManager;
    private void Start()
    {
        _soundManager = SoundManager.Instance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        _soundManager.AudioSelection(16, 0.5f);
        collision.gameObject.GetComponent<WinAnimations>().endAnimation();
        collision.gameObject.active = false;
    }
}
