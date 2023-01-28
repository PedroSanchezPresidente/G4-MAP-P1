using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    public void onHit()
    {
        Debug.Log("objeto");
    }
}
