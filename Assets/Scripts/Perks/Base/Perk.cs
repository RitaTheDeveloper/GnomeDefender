using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk
{
    public PerkTierType Tier { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Sprite Icon { get; private set; }
    public float Value { get; protected set; }    

    public void SetDescription(PerkTierType tier, string title, string description, Sprite iconSprite, float value)
    {
        Tier = tier;
        Title = title;
        Description = description;
        Icon = iconSprite;
        Value = value;
    }

    public virtual void AddPerk()
    {

    }
        
}
