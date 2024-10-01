using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerGnomeState : IState
{
    GnomeSM _gnomeSM;
    SpriteRenderer _bodySR;
    Color _minerBodyColor = Color.black;
    Color _startingBodyColor;
    CurrencyController _currencyController;
    public MinerGnomeState(GnomeSM gnomeSM, SpriteRenderer spriteRenederer, CurrencyController currencyController)
    {
        _gnomeSM = gnomeSM;
        _bodySR = spriteRenederer;
        _currencyController = currencyController;
    }

    public void Enter()
    {
        _startingBodyColor = _bodySR.color;
        _bodySR.color = _minerBodyColor;
        _currencyController.DoubleGold = true;
    }

    public void Exit()
    {
        _bodySR.color = _startingBodyColor;
        _currencyController.DoubleGold = false;
    }

    public void FixedTick()
    {
        
    }

    public void Tick()
    {
        //
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
