using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public Action onLose, onWin;

    [SerializeField] private GameObject _town;
    [SerializeField] private GameObject _player;
    [SerializeField] private SpawnerController _spawnerController;
    [SerializeField] private TimeController _timeController;

    private bool _isGameOver;
    public GameObject Town { get => _town; set => _town = value; }
    public GameObject Player { get => _player; set => _player = value; }
    public bool IsGameOver { get => _isGameOver; set => _isGameOver = value; }

    private void OnEnable()
    {
        _timeController.onTimeIsUp += Win;

        if (_player)
        {
            _player.GetComponent<Health>().onDead += Lose;
        }
        if (_town)
        {
            _town.GetComponent<Health>().onDead += Lose;
        }

    }

    private void OnDisable()
    {
        _timeController.onTimeIsUp -= Win;

        if (_player)
        {
            _player.GetComponent<Health>().onDead -= Lose;
        }

        if (_town)
        {
            _town.GetComponent<Health>().onDead -= Lose;
        }

    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {        
        _spawnerController.Init(this);
    }
    public void Win()
    {
        onWin.Invoke();
        Debug.Log("game is won");
    }

    public void Lose()
    {
        onLose.Invoke();
        _timeController.StopTime();
        _isGameOver = true;
        Debug.Log("game is over");
    }
}
