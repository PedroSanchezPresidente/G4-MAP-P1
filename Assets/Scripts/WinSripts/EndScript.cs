using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<WinAnimations>().endAnimation();
        collision.gameObject.active = false;
        Invoke("cambiarScena", 4);
    }

    private void cambiarScena()
    {
        SceneManager.LoadScene("UIScene + Coins", LoadSceneMode.Single);
        //GameManager.Instance.RequestStateChange(GameManager.GameStates.START);
    }
}
