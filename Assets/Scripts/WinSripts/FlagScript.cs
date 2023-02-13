using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void winDown()
    {
        _rigidbody2D.gravityScale = 0f;
        _rigidbody2D.velocity = new Vector2(0, -3);
    }
}
