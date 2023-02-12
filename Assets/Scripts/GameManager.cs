using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStates { START, GAME, GAMEOVER };

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
    private int _points;
    public int _lifes;
    private float _remainingTime;
    private int _coins;

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
    private void OnPickCoin()
    {

    }
    private void EnterState(GameStates newState)
    {
        _UIManager.SetMenu(newState);
        switch (newState)
        {
            case GameStates.GAME:
                Debug.Log("GAME");
                _UIManager.SetUpGameHUD(_remainingTime);
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
    
    private void UpdateState(GameStates state)
    {
        switch (state)
        {
            case GameStates.GAME:
                _remainingTime -= Time.deltaTime;
                //Debug.Log("tempo");
                if (_remainingTime < 0)
                {
                    PlayerManager.Instance.ChangeState(PlayerManager.PlayerStates.MUERTO);
                    _nextState = GameStates.GAMEOVER;
                }
                _UIManager.UpdateGameHUD(_remainingTime);
                break;
            case GameStates.START:
            case GameStates.GAMEOVER:
                break;
        }
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
