using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    private Animator _animator;
    public bool isActivated = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void onHit()
    {
        isActivated = true;
        _animator.SetBool("IsActivated", isActivated);
        Debug.Log("objeto");
    }
}
