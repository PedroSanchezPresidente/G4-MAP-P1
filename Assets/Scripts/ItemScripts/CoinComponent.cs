using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    public Transform _coinSpawn;
    public GameObject _coinPrefab;
    [SerializeField]
    public int _blockCoins;


    
    public void GetCoin()
    {
        if (_blockCoins > 0)
        {
            _blockCoins--;
            GameManager.Instance._coins++;
            
            if (_blockCoins == 0)
            {
                GetComponent<BlockComponent>().BlockIsActivated();
            }
        }
    }

}
