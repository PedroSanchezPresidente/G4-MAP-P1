using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGrid : MonoBehaviour
{
    [SerializeField] GameObject _blocksGrid;
    private GameObject _currentBlocks;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _currentBlocks = Instantiate(_blocksGrid, _transform);
    }
    public void InstanciateGrid()
    {
        Destroy(_currentBlocks);
        _currentBlocks = Instantiate(_blocksGrid, _transform);
    }
}
