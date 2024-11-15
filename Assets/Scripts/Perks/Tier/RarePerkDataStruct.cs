using UnityEngine;

[System.Serializable]
public struct RarePerkDataStruct
{
    [field: SerializeField] public PerkTierType TierType { get; private set; }
    [field: SerializeField] public float Weight { get; private set; }
    [field: SerializeField] public string TierString { get; private set; }
    [field: SerializeField] public Color TierColor { get; private set; }
    
}
