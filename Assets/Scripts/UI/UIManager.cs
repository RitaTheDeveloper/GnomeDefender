using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UIWinAndLose _uIWinAndLose;
    [SerializeField] private UIGameMenu _uiGameMenu;
    [SerializeField] private UISelectionMenu _uISelectionMenu;
    [SerializeField] private CameraController _cameraController;

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
       
    }

    private void Start()
    {
        AllOff();
        _uISelectionMenu.gameObject.SetActive(true);
        _uISelectionMenu.Init(this);

       // GameMenuOn();
    }

    private void FixedUpdate()
    {
        if (_uiGameMenu.isActiveAndEnabled)
        {
            _uiGameMenu.ShowTime(_timeController.CurrentTime);
        }
        
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
        _uISelectionMenu.gameObject.SetActive(false);
        _uiGameMenu.gameObject.SetActive(false);
    }

    public void GameMenuOn()
    {
        AllOff();
        _uiGameMenu.gameObject.SetActive(true);
        _timeController = _gameManager.GetComponent<TimeController>();
        _gameManager.Init();
        _uiGameMenu.Init(_gameManager.Player.GetComponent<GnomeController>(), _gameManager.Town.GetComponent<TownController>(), _gameManager);
        _cameraController.SetTarget(_gameManager.Player.transform);

    }
}
