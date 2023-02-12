using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour
{

    float timer;
    [SerializeField] float timeToDestroy;

    private void Start()
    {
        timer = 0;
    }
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > timeToDestroy)
            Destroy(gameObject);
    }
}
