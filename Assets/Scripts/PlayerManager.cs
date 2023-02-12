using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
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
    private SoundManager _soundManager;
    //Public renference of Player Manager
    static public PlayerManager Instance { get { return _instance; } }
    //referencia estadi actual
    [SerializeField] private PlayerStates _currentState;
    //refencia estado siguiente
    private PlayerStates _nextState;
    public PlayerStates _basicState = PlayerStates.PEQUEÑO;
    //refencia publica del estado actual
    public PlayerStates CurrentState { get { return _currentState; } }
    private Animator _animator;
    [SerializeField]
    private GameObject _diedMario;//prefab mario muerto

    [SerializeField]
    private GameObject _spawn;

    [SerializeField]
    private FollowCamera _camera;
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
    private void GoToSpawn()
    {
        this.transform.position = _spawn.transform.position;
        _camera.ResetCamera();
    }
    private void EnterState(PlayerStates newState)
    {
        switch (newState)
        {
            case PlayerStates.PEQUEÑO:
                _animator.SetBool("Fire", false);
                _animator.SetBool("Big", false); 
                break;
            case PlayerStates.GRANDE:
                _animator.SetBool("Fire", false);
                _animator.SetBool("Big", true);
                break;
            case PlayerStates.FUEGO:
                _animator.SetBool("Fire", true);
                _animator.SetBool("Big", true);
                //intanciar sprite fuego
                //Activar script Lanza Fuego
                break;
            case PlayerStates.ESTRELLA:
                //invencibilidad (desactivar script killPlayer y activar el script killEnemyStar)
                GetComponent<KillPlayerComponent>().enabled = false;
                break;
            case PlayerStates.MUERTO:
                GetComponent<MovementComponent>().enabled = false;
                _animator.SetBool("isDead", true);
                _soundManager.StopAudio();
                _soundManager.AudioSelection(4, 0.5f);
                //if (GameManager.Instance._lifes > 0)
                //{
                //    GameManager.Instance.BajaVida();
                //    GameManager.Instance.RequestStateChange(GameManager.GameStates.RETRY);
                //}
                GameManager.Instance.RequestStateChange(GameManager.GameStates.GAMEOVER);
                GoToSpawn();
                break;
        }
        
    }
    private void ExitState(PlayerStates state)
    {
        switch (state)
        {
            case PlayerStates.PEQUEÑO:
                
                break;
            case PlayerStates.GRANDE:
                //activar animacion de hacerse pequeño
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

                break;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _currentState = PlayerStates.PEQUEÑO;
    }
    // Update is called once per frame
    void Update()
    {
        _soundManager = SoundManager.Instance;
        if (_nextState != _currentState)
        {
            ExitState(_currentState);
            _currentState = _nextState;
            EnterState(_currentState);
        }
        
    }


}