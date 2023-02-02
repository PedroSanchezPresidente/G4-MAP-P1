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
    public enum PlayerStates {PEQUEÑO, GRANDE, FUEGO, ESTRELLA, MUERTO}
    //posibles referencias futuras 
    #endregion

    #region Properties
    //Instancia del Player Manager
    static private PlayerManager _instance;
    //Public renference of Player Manager
    static public PlayerManager Instance { get { return _instance; } }
    //referencia estadi actual
    [SerializeField] private PlayerStates _currentState;
    //refencia estado siguiente
    private PlayerStates _nextState;
    //refencia publica del estado actual
    public PlayerStates CurrentState { get { return _currentState; } }
    #endregion
    #region Methods
    //Inicialización de Player Manager
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
            case PlayerStates.PEQUEÑO:
                //instanciar sprite Mario Pequeño
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
                break;
            case PlayerStates.MUERTO: 
                Destroy(gameObject);
                //llamar al GameManager para deshabilitar scripts
                break;
        }
        
    }
    private void ExitState(PlayerStates newState)
    {
        switch (newState)
        {
            case PlayerStates.PEQUEÑO:
                //destruir sprite mario pequeño
                break;
            case PlayerStates.GRANDE:
                //destruir sprite mario grande
                break;
            case PlayerStates.FUEGO:
                //destruir sprite mario fuego
                //lanzaFuego.enable = false
                break;
            case PlayerStates.ESTRELLA:
                //deshabilitar script Estrella, habiliatar KillPlayer y deshabilitar KillEnemyStar
                break;
            case PlayerStates.MUERTO:
                break;
        }
    }
    private void UpdateState(PlayerStates state)
    {
        switch (state)
        {
            case PlayerStates.ESTRELLA:
                
                break;
            case PlayerStates.PEQUEÑO:
            case PlayerStates.GRANDE:
            case PlayerStates.FUEGO:
            case PlayerStates.MUERTO:
                break;
        }
    } 


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _currentState = PlayerStates.MUERTO;
        _nextState = PlayerStates.PEQUEÑO;
    }
    // Update is called once per frame
    void Update()
    {
        if (_nextState != _currentState)
        {
            ExitState(_currentState);
            _currentState = _nextState;
            EnterState(_nextState);
        }
        UpdateState(_currentState);
    }


}