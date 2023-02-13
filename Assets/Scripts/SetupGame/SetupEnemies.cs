using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupEnemies : MonoBehaviour
{
    public GameObject[] _enemies;
    [SerializeField] private Vector2[] _startPositions;
    void Start()
    {
        _startPositions = new Vector2[_enemies.Length];
        for (int i = 0; i < _enemies.Length; i++)
        {
            _startPositions[i] = _enemies[i].GetComponent<Transform>().position;
        }
    }
    public void StartEnemies()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].SetActive(true);
            _enemies[i].transform.position = _startPositions[i];
        }
    }
}
