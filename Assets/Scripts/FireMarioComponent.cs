using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMarioComponent : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointRight;
    private SoundManager _soundManager;
    [SerializeField] private Transform _spawnPointLeft;
    [SerializeField] private GameObject _fireRight;
    [SerializeField] private GameObject _fireLeft;
    [SerializeField] public float _speed;
    float _timer;
    float _timeToFire;
    private void Start()
    {
        _soundManager = SoundManager.Instance;
        _timeToFire = 0.2f;
        _timer = 0;
    }
    public void Update()
    {
        _timer = _timer + Time.deltaTime;
    }
    public void Fire()
    {
        if (PlayerManager.Instance.CurrentState == PlayerManager.PlayerStates.FUEGO && _timer > _timeToFire)
        {
            _timer = 0;
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GameObject instanced = Instantiate(_fireLeft, _spawnPointLeft);
                instanced.GetComponent<Rigidbody2D>().velocity = new Vector2(-_speed, 0);
            }
            else
            {
                GameObject instanced = Instantiate(_fireRight, _spawnPointRight);
                instanced.GetComponent<Rigidbody2D>().velocity = new Vector2(_speed, 0);
            }
            _soundManager.AudioSelection(6, 0.5f);
            
        }
    }
}
