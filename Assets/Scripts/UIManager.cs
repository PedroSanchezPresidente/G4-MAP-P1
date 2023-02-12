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
    [SerializeField] private GameObject[] _menus;
    #endregion

    #region properties
    //array de distintos menus

    #endregion

    #region methods
    public void SetUpGameHUD(float remainingTime, int lifes)
    {
        int aux = (int)remainingTime;
        _remainingTime.text = aux.ToString();

        _lifes.text = lifes.ToString();
    }
    public void UpdateGameHUD(float remainingTime, int lifes, int _currentCoins, int _currentPoints)
    {
        int aux = (int)remainingTime;
        _remainingTime.text = aux.ToString();
        _lifes.text = lifes.ToString();
        _coins.text = "x" + _currentCoins.ToString();
        _points.text = _currentPoints.ToString();
    }

    public void RequestStateChange(int newState)
    {
        GameManager.Instance.RequestStateChange((GameManager.GameStates) newState);
        SetMenu((GameManager.GameStates)newState);
    }

   
    public void SetMenu(GameManager.GameStates newMenu)
    {
        for (int i = 0; i < _menus.Length; i++)
        {
            _menus[i].SetActive(false);
        }
        _menus[(int)newMenu].SetActive(true);
    }
    #endregion
    private void Start()
    {
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
