using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Sprite Icon { get; private set; }

    public float Value { get; private set; }

    public void SetDescription(string title, string description, Sprite iconSprite, float value)
    {
        Title = title;
        Description = description;
        Icon = iconSprite;
        Value = value;
    }

    public virtual void AddPerk()
    {

    }
        
}
