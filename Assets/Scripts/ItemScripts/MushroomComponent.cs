using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomComponent : MonoBehaviour
{
    [SerializeField] float itemSpeed;
    private Rigidbody2D _itemRigidbody;
    private SoundManager _SoundManager;
    private Animator _animator;

    public void Begin()
    {
        _itemRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _SoundManager = SoundManager.Instance;
        _SoundManager.AudioSelection(4, 0.5f);
    }
    private void FixedUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            _animator.enabled = false;
            _itemRigidbody.velocity = new Vector2(-itemSpeed * Time.deltaTime, -itemSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.layer == 6) //layer del player
        {
            if (PlayerManager.Instance.CurrentState == PlayerManager.PlayerStates.PEQUEÑO)
            {
                _SoundManager.AudioSelection(3, 0.5f);
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
