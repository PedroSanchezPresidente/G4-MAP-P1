using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region references
    [SerializeField] private TMP_Text _points;
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private TMP_Text _lifes;

    //tiempo
    [SerializeField] private TMP_Text _remainingTime;

    //MENUS
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _gameplayHUD;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _retryMenu;
    #endregion

    #region properties
    //array de distintos menus
    private GameObject[] _menus;
    #endregion
    #region methods
    public void SetUpGameHUD(float remainingTime, int lifes)
    {
        int aux = (int)remainingTime;
        _remainingTime.text = aux.ToString();

        _lifes.text = lifes.ToString();
    }
    public void UpdateGameHUD(float remainingTime, int lifes)
    {
        int aux = (int)remainingTime;
        _remainingTime.text = aux.ToString();

        _lifes.text = lifes.ToString();

    }
   
    public void SetMenu(GameManager.GameStates newMenu)
    {
        for (int i = 0; i < _menus.Length; i++)
        {
            _menus[i].SetActive(false);
        }
        _menus[(int)newMenu].SetActive(true);
        if ((int)newMenu == 1) Debug.Log("GaemHUD");

    }
    #endregion
    private void Start()
    {
        _menus = new GameObject[4];
        _menus[0] = _startMenu;
        _menus[1] = _gameplayHUD;
        _menus[2] = _retryMenu;
        _menus[3] = _gameOverMenu;
        GameManager.Instance.RegisterUIManager(this);
    }


    /*

    public void SetUpMenu()
    {
        // comentado porque no estan implementados aun, añadir luego 
        //_puntuacion.text = " " + _puntos;
        //_monedas.text = " " + _monedasCant;
        _tiempo.text = " " + (int)_currentTime;
    }

    // Restarts the timer
    private void ResetTimer()
    {
        _currentTime = _timerDuration;
    }
    private void Timer()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime * 3;
            //Debug.Log(_currentTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        SetUpMenu();
    }*/
}
