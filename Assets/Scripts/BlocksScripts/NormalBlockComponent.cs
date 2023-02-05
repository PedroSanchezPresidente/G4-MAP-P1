using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBlockComponent : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerManager _playerManager;
    private GameObject _block;
    private SoundManager _soundManager;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerManager = collision.gameObject.GetComponent<PlayerManager>();

        if (_playerManager.CurrentState == _playerManager._basicState)
        {
            Debug.Log("Animacion");
        }
        else
        {
            _soundManager.AudioSelection(7, 0.8f);
            Destroy(_block);
        }
    }

    void Start()
    {
        _soundManager = SoundManager.Instance;
        _block = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
