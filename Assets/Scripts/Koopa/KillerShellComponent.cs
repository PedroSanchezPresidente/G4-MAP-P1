using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerShellComponent : MonoBehaviour
{
    [SerializeField] private ShellComponent _shellComponent;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && _shellComponent.speed == 4 || _shellComponent.speed == -4) //evalua si choca con mario
        {
            PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.MUERTO);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") && _shellComponent.speed != 0)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("ScreenLimits"))
        {
            _shellComponent.Death();
        }
    }
}
