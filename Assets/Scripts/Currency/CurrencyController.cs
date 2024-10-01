using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    [field: SerializeField] public int GoldPerSec { get; private set; }
    
    public int TotalAmountOfGold { get; private set; }
    public bool DoubleGold { get; set; } = false;

    private float _delayAmount = 1f;
    private float _timer;

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= _delayAmount)
        {
            _timer = 0f;
            IncreaseTotalGold();
        }
    }

    private void IncreaseTotalGold()
    {
        if (DoubleGold)
        {
            TotalAmountOfGold += 4 * GoldPerSec;
        }
        else
        {
            TotalAmountOfGold += GoldPerSec;
        }
        
    }
}
