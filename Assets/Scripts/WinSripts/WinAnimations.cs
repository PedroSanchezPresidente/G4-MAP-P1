using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimations : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SoundManager _soundManager;
    private bool _toCastle = false;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _soundManager = SoundManager.Instance;
    }

    public void winDown()
    {
        _soundManager.StopAudio();
        _rigidbody2D.gravityScale = 0f;
        _rigidbody2D.velocity = new Vector2(0, -3);       
        _soundManager.AudioSelection(15, 0.5f);
    }

    public void toCastle()
    {
        _rigidbody2D.gravityScale = 3f;
        _toCastle = true;
    }

    public void endAnimation()
    {
        _toCastle = false;
        this.enabled = false;
    }

    private void Update()
    {
        if (_toCastle)
        {
            float y = _rigidbody2D.velocity.y;
            _rigidbody2D.velocity = new Vector2(3, y);
        }
    }
    
}
