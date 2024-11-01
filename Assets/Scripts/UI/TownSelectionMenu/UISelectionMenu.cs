using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectionMenu : MonoBehaviour
{
    [SerializeField] private TownGenerator _townGenerator;

    private UIManager _uIManager;    

    public void Init(UIManager uIManager)
    {
        _uIManager = uIManager;
    }

    public void OnClickSelectTown(int index)
    {
        _townGenerator.SetTown(index);
        _uIManager.GameMenuOn();
    }
}
