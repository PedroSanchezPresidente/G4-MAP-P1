using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Reference
    //Player States
    public enum PlayerStates {PEQUE�O, GRANDE, FUEGO, ESTRELLA, MUERTO}
    //posibles referencias futuras 
    #endregion
    
    #region Properties
    //Instancia del Player Manager
    static private PlayerManager _instance;
    //Public renference of Player Manager
    static public PlayerManager Instance { get { return _instance; } }
    //referencia estadi actual
    private PlayerStates _currentState;
    //refencia estado siguiente
    private PlayerStates _nextState;
    //refencia publica del estado actual
    public PlayerStates CurrentState { get { return _currentState; } }

    [SerializeField]
    private GameObject _diedMario;//prefab mario muerto

    private Transform _dMTransform;
    #endregion
    #region Methods
    //Inicializaci�n de Player Manager
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
    public void ChangeState(PlayerStates nextState)
    {
        _nextState = nextState;
    }
    private void EnterState(PlayerStates newState)
    {
        switch (newState)
        {
            case PlayerStates.PEQUE�O:
                //instanciar sprite Mario Peque�o
                break;
            case PlayerStates.GRANDE:
                // instanciar sprite Mario Grande
                break;
            case PlayerStates.FUEGO:
                //intanciar sprite fuego
                //Activar script Lanza Fuego
                break;
            case PlayerStates.ESTRELLA:
                //invencibilidad (desactivar script killPlayer y activar el script killEnemyStar)
                this.GetComponent<KillPlayerComponent>().enabled = false;
                break;
            case PlayerStates.MUERTO:

                //activar animacion de muerte
                Destroy(gameObject);
                //comprobar si las vidas
                //if > 0, vidas--;
                //else llamar funci�n GameOver que desactiva todos los scripts en ejecucion (input) y se pone el texto GameOver
                

                _diedMario.GetComponent<DyingMarioComponent>().DieJump();
                //llamar al GameManager para deshabilitar scripts
                break;
        }
        
    }
    private void ExitState(PlayerStates state)
    {
        switch (state)
        {
            case PlayerStates.PEQUE�O:
                
                break;
            case PlayerStates.GRANDE:
                //activar animacion de hacerse peque�o
                break;
            case PlayerStates.FUEGO:
                //activar animacion de FireMario
                //Activar script Lanza Fuego
                break;
            case PlayerStates.ESTRELLA:
                //invencibilidad (desactivar script killPlayer y activar el script killEnemyStar)
                this.GetComponent<KillPlayerComponent>().enabled = true;
                break;
            case PlayerStates.MUERTO:

                //activar animacion de muerte
                Destroy(gameObject);
                //comprobar si las vidas
                //if > 0, vidas--;
                //else llamar funci�n GameOver que desactiva todos los scripts en ejecucion (input) y se pone el texto GameOver


                _diedMario.GetComponent<DyingMarioComponent>().DieJump();
                //llamar al GameManager para deshabilitar scripts
                break;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _dMTransform = _diedMario.GetComponent<Transform>();
        _currentState = PlayerStates.MUERTO;
        _nextState = PlayerStates.PEQUE�O;
    }
    // Update is called once per frame
    void Update()
    {
        if (_nextState != _currentState)
        {
            ExitState(_currentState);
            _currentState = _nextState;
            EnterState(_currentState);
        }
        
    }


}