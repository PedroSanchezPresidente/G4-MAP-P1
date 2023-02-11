using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public enum GameStates { START, GAME, RETRY, GAMEOVER };

    #region references
    private UIManager _UIManager;

    [SerializeField] GameObject _player;

    #endregion

    #region properties

    static private GameManager _instance;

    static public GameManager Instance { get { return _instance; } }

    private GameManager.GameStates _currentState;

    private GameManager.GameStates _nextState;
    public GameManager.GameStates CurrentState { get { return _currentState; } }
    public int _points = 0;
    public int _lifes = 3;
    private float _remainingTime;
    public int _coins = 0;


    #endregion

    #region Methods
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
    public void RegisterUIManager(UIManager uiManager)
    {
        if (_UIManager == null)
        {
            _UIManager = uiManager;
        }
    }
   
    public void OnPickCoin()
    {
        _coins++;
        Debug.Log(_coins);
    }

    public void Experience(int _exp)
    {
        _points += _exp;
    }

    private void EnterState(GameStates newState)
    {
        _UIManager.SetMenu(newState);
        switch (newState)
        {
            case GameStates.GAME:
                Debug.Log("GAME");
                _UIManager.SetUpGameHUD(_remainingTime, _lifes);
                PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.PEQUE�O);
                break;
            case GameStates.START:
            case GameStates.GAMEOVER:
                break;
        }
    }
    private void ExitState(GameStates state)
    {
        switch (state)
        {
            case GameStates.GAME:
            case GameStates.START:
            case GameStates.GAMEOVER:
                break;
        }
    }
    
    public void UpdateState(GameStates state)
    {
        switch (state)
        {
            case GameStates.GAME:
                _remainingTime -= Time.deltaTime;
                //Debug.Log("tempo");
                if (_remainingTime < 0 || _lifes <= 0)
                {
                    _nextState = GameStates.GAMEOVER;
                }
                _UIManager.UpdateGameHUD(_remainingTime, _lifes, _coins, _points );
                break;
            case GameStates.RETRY:
                _UIManager.UpdateGameHUD(_remainingTime, _lifes, _coins, _points);
                break;
            case GameStates.START:

            case GameStates.GAMEOVER:
                break;
        }
    }

    public void BajaVida()
    {
        _lifes--;
    }

    public void RequestStateChange(GameStates sigState)
    {
        _nextState = sigState;
        
    } 




    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _remainingTime = 400;
        _nextState = GameStates.GAME;
        _currentState = GameStates.START;
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
