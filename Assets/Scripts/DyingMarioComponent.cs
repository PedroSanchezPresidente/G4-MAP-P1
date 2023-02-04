using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingMarioComponent : MonoBehaviour
{
    [SerializeField]
    private float _jForce;
    private Rigidbody2D _myRigidBody;

    public void DieJump()
    {
        _myRigidBody.AddForce(Vector2.up * _jForce, ForceMode2D.Impulse);
    }
    private void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        
    }



}
