using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Perks/PerkTierStruct", fileName = "PerkTierStruct")]
public class PerkTierStruct : ScriptableObject
{
    [field:SerializeField] public List<RarePerkDataStruct> PerkTierDataStruct  = new List<RarePerkDataStruct>();
}
