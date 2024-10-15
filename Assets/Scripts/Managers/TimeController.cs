using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeController : MonoBehaviour
{
    public Action onTimeIsUp;
    public float time;

    private float _currentTime;
    private bool _stopTime;

    public float CurrentTime { get => _currentTime; }

    private void Start()
    {
        _currentTime = time;
        _stopTime = false;
    }

    private void FixedUpdate()
    {
        if (!_stopTime)
        {
            CountingTime();
        }
    }

    private void CountingTime()
    {
        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
        }
        else
        {
            TimeIsUp();
        }        
    }

    public void TimeIsUp()
    {
        onTimeIsUp.Invoke();
        Time.timeScale = 0f;
    }

    public void StopTime()
    {
        _stopTime = true;
        Time.timeScale = 0f;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1f;
    }
}
