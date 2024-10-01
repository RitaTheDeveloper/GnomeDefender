using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeSM : StateMachine
{
    [SerializeField] private SpriteRenderer _spriteRender;
    private IAttacker _attacker;
    public MinerGnomeState MinerState { get; private set; }
    public KillerGnomeState KillerState { get; private set; }

    private void Awake()
    {
        _attacker = GetComponent<IAttacker>();
        MinerState = new MinerGnomeState(this, _spriteRender);
        KillerState = new KillerGnomeState(this, _spriteRender, _attacker);
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(KillerState);
    }

    // Update is called once per frame
    void Update()
    {
        
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
