using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeSM : StateMachine
{
    [SerializeField] private GameManager gameManager; // пока указываем ссылку, но потом сам GM должен спавнить плеера и передавать себя ему
    [SerializeField] private SpriteRenderer _spriteRender;
    private IAttacker _attacker;
    public MinerGnomeState MinerState { get; private set; }
    public KillerGnomeState KillerState { get; private set; }

    private CurrencyController _currencyController;

    private void Awake()
    {
        _attacker = GetComponent<IAttacker>();
        _currencyController = gameManager.Town.GetComponent<CurrencyController>();
        MinerState = new MinerGnomeState(this, _spriteRender, _currencyController);
        KillerState = new KillerGnomeState(this, _spriteRender, _attacker);
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(KillerState);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Town")
        {
            ChangeState(MinerState);
        }           
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Town")
        {
            ChangeState(KillerState);
        }
            
    }
}
