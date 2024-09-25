using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWinAndLose : MonoBehaviour
{
    [SerializeField] private GameObject _loseObj;
    [SerializeField] private GameObject _winObj;

    public void Lose()
    {
        AllOff();
        _loseObj.SetActive(true);
    }

    public void Win()
    {
        AllOff();
        _winObj.SetActive(true);
    }

    private void AllOff()
    {
        _loseObj.SetActive(false);
    }
}
