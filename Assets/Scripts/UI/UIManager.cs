using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UIWinAndLose _uIWinAndLose;
    [SerializeField] private UIGameMenu _uiGameMenu;

    private TimeController _timeController;

    private void OnEnable()
    {
        _gameManager.onLose += Lose;
        _gameManager.onWin += Win;
    }

    private void OnDisable()
    {
        _gameManager.onLose -= Lose;
        _gameManager.onWin -= Win;
    }
    private void Awake()
    {
        _timeController = _gameManager.GetComponent<TimeController>();
        _uiGameMenu.Init(_gameManager.Player.GetComponent<GnomeController>(), _gameManager);
    }

    private void Start()
    {
        AllOff();
    }

    private void FixedUpdate()
    {
        _uiGameMenu.ShowTime(_timeController.CurrentTime);
    }

    public void Lose()
    {
        _uIWinAndLose.gameObject.SetActive(true);
        _uIWinAndLose.Lose();
    }

    public void Win()
    {
        _uIWinAndLose.gameObject.SetActive(true);
        _uIWinAndLose.Win();
    }

    private void AllOff()
    {
        _uIWinAndLose.gameObject.SetActive(false);
    }
}
