using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkConfig : ScriptableObject
{
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }

    [field: SerializeField] public float Value { get; private set; }
    public Perk _perk { get; private set; }

    public virtual void Init()
    {
        //_perk = perk;
        _perk.SetDescription(Title, Description, Icon, Value);
    }

    public void SetPerk(Perk perk)
    {
        _perk = perk;
    }    
}
