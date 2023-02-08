using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{

    public void GetCoin()
    {
        GameManager.Instance.OnPickCoin();
        //destruye el objeto despues de la animacion (+ un delay ???)
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1);  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
