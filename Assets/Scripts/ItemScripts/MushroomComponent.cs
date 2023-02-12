using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomComponent : MonoBehaviour
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
            _itemRigidbody.velocity = new Vector2(itemSpeed , Y );
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.layer == 6) //layer del player
        {
            if (PlayerManager.Instance.CurrentState == PlayerManager.PlayerStates.PEQUEÑO)
            {
                _soundManager.AudioSelection(1, 0.5f);
                GameManager.Instance.Experience(1000);
                PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.GRANDE);
                Destroy(gameObject);
            }
            else
            {
                // dar puntos 
            }

        }
    }
}
