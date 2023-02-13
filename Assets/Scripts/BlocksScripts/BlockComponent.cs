using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private GameObject _mushroomPrefab;
    [SerializeField]
    private GameObject _fireFlowerPrefab;
    [SerializeField]
    //private GameObject _coinPrefab;
    private Animator _animator;
    [SerializeField] 
    private GameObject _coinPrefab;

    [SerializeField]
    public int _blockCoins;

    public bool isActivated = false;

    public bool containsMushroom;
    public bool containsFireFlower;
    public bool containsCoin;
    //public bool containsCoin;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void onHit()
    {
        //isActivated = true;
        _animator.SetBool("IsActivated", isActivated);

        if (containsMushroom)
        {
            GameObject item = Instantiate(_mushroomPrefab, transform);
            item.GetComponent<MushroomComponent>().Begin();
            GameManager.Instance.Experience(200);
            BlockIsActivated();
        }
        else if (containsFireFlower)
        {
            GameObject item = Instantiate(_fireFlowerPrefab, transform);
            GameManager.Instance.Experience(200);
            BlockIsActivated();
        }
        else if (containsCoin) 
        {
            if (_blockCoins > 0)
            {
                GameObject item = Instantiate(_coinPrefab, transform.position , Quaternion.identity);
                GameManager.Instance.OnPickCoin();
                GameManager.Instance.Experience(200);
                _blockCoins--;

                if (_blockCoins == 0)
                {
                    BlockIsActivated();
                }
            }
        }
    }

    public bool BlockIsActivated()
    {
        isActivated = true;
        _animator.SetBool("IsActivated", isActivated);
        return isActivated;
    }
}
