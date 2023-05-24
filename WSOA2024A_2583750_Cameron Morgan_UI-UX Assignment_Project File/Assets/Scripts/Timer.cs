using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI _timerText;

    public float _currentTime;
    public bool countDown;

    public bool Limit;
    public float _timerLimit;

    private void Update()
    {
        _currentTime = countDown ? _currentTime -= Time.deltaTime : _currentTime += Time.deltaTime;

        if (Limit && ((countDown && _currentTime <= _timerLimit) || (!countDown && _currentTime >= _timerLimit)))
        {
            _currentTime = _timerLimit;
            SetTimer();
            enabled = false;
        }

        SetTimer(); 


    }

    void SetTimer()
    {
        _timerText.text = _currentTime.ToString("0.0");
    }

}
