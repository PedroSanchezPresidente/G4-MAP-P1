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
    private Animator _animator;
    public bool isActivated = false;

    public bool containsMushroom;
    public bool contains1UP;
    public bool containsFireFlower;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void onHit()
    {
        isActivated = true;
        _animator.SetBool("IsActivated", isActivated);
        if (containsMushroom)
        {
            GameObject item = Instantiate(_mushroomPrefab, transform);
            item.GetComponent<MushroomComponent>().Begin();
        }
        else if (contains1UP)
        {
            GameObject item = Instantiate(_mushroomPrefab, transform);
            item.GetComponent<OneUPComponent>().Begin();
        }
        else if (containsFireFlower) 
        {
            GameObject item = Instantiate(_fireFlowerPrefab, transform);
        }
    }
}
