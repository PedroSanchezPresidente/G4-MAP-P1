using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region references
    [SerializeField] private TMP_Text _puntuacion;
    [SerializeField] private TMP_Text _monedas;

    //tiempo
    [SerializeField] private TMP_Text _tiempo;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _timerDuration;
    
    #endregion


    void MenuSetUp()
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
            Debug.Log(_currentTime);
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
        MenuSetUp();
    }
}
