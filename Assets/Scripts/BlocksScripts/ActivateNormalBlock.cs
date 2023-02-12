using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNormalBlock : MonoBehaviour
{
    private Animator _animator;
    public bool isActivated = false;
    // Start is called before the first frame update
    public void onHit()
    {
        isActivated = true;
        _animator.SetBool("IsActivated", isActivated);
    }
    public void NoHit()
    {
        isActivated = false;
        _animator.SetBool("IsActivated", isActivated);
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
