using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGold : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldTxt;
    [SerializeField] private CurrencyController _currencyController;

    private void Update()
    {
        UpdateGold();
    }

    private void UpdateGold()
    {
        _goldTxt.text = _currencyController.TotalAmountOfGold.ToString();
    }
}
