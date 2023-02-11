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
            BlockIsActivated();
        }
        else if (containsFireFlower)
        {
            GameObject item = Instantiate(_fireFlowerPrefab, transform);
            BlockIsActivated();
        }
        else if (containsCoin) 
        {
            GetComponent<CoinComponent>().GetCoin();
            GameManager.Instance.Experience(200);
            _animator.SetBool("IsActivated", isActivated);
        }
        else
        {
            BlockIsActivated();
        }
    }

    public bool BlockIsActivated()
    {
        isActivated = true;
        _animator.SetBool("IsActivated", isActivated);
        return isActivated;
    }
}
