using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUPComponent : MonoBehaviour
{
    [SerializeField] float itemSpeed;
    private Rigidbody2D _itemRigidbody;
    private Animator _animator;
    private SoundManager _soundManager;

    public void Begin()
    {
        _soundManager = SoundManager.Instance;
        _itemRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _soundManager.AudioSelection(2, 0.5f);
    }
    private void FixedUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            float Y = _itemRigidbody.velocity.y;
            _animator.enabled = false;
            _itemRigidbody.velocity = new Vector2(itemSpeed, Y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //layer del player
        {
            GameManager.Instance._lifes++;
            Destroy(gameObject);

        }
    }
}
