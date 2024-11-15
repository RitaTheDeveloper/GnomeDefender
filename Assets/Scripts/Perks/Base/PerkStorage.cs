using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkStorage : MonoBehaviour
{
    [SerializeField] public PerkTierStruct PerkTierStruct;
    [SerializeField] private PerkConfig[] _perkConfigs;
    [SerializeField] private int _numberOfProposedPerks = 3;
    public List<Perk> AllPerks { get; private set; } = new List<Perk>();

    private Dictionary<PerkTierType, List<Perk>> _perkListOfTier = new Dictionary<PerkTierType, List<Perk>>();

    private void Awake()
    {
        // Init();
        
    }

    public void Init()
    {
        for (int i = 0; i < _perkConfigs.Length; i++)
        {
            _perkConfigs[i].Init();
            AllPerks.Add(_perkConfigs[i]._perk);
        }
        _perkListOfTier = CreatePerkListOfTier(AllPerks);
    }

    public List<Perk> GetProposedPerksList()
    {
        List<Perk> listOfPerks = new List<Perk>();

        for (int i = 0; i < _numberOfProposedPerks; i++)
        {
            int randIndex = Random.Range(0, AllPerks.Count - 1);
            listOfPerks.Add(AllPerks[randIndex]);
        }
        return listOfPerks;
    }

    public List<Perk> GetRandomProposedPerkList()
    {
        List<Perk> proposedListOfPerks = new List<Perk>();
        List<Perk> generalList = new List<Perk>();
        generalList.AddRange(AllPerks);
        _perkListOfTier = CreatePerkListOfTier(generalList);

        for (int i = 0; i < _numberOfProposedPerks; i++)
        {
            var tier = GetRandomPerkTier(generalList);
            int randIndex = Random.Range(0, _perkListOfTier[tier].Count);
            var perk = _perkListOfTier[tier][randIndex];
            proposedListOfPerks.Add(perk);
            _perkListOfTier[tier].Remove(perk);
            generalList.Remove(perk);
        }

        return proposedListOfPerks;
    }

    private PerkTierType GetRandomPerkTier(List<Perk> perkList)
    {
        PerkTierType perkTier = PerkTierType.First;

        float totalWeight = 0;

        foreach (var entry in perkList)
        {
            totalWeight += PerkTierStruct.PerkTierDataStruct[(int)entry.Tier].Weight;
        }

        var randomWeightValue = Random.Range(0, totalWeight);

        float processedWeight = 0;

        foreach (var entry in perkList)
        {
            processedWeight += PerkTierStruct.PerkTierDataStruct[(int)entry.Tier].Weight;
            if (randomWeightValue <= processedWeight)
            {
                perkTier = entry.Tier;
                break;
            }
        }
        return perkTier;
    }

    private Dictionary<PerkTierType, List<Perk>> CreatePerkListOfTier(List<Perk> generalPerkList)
    {
        Dictionary<PerkTierType, List<Perk>> perkListOfTier = new Dictionary<PerkTierType, List<Perk>>();
        

        for (int i = 0; i < generalPerkList.Count; i++)
        {
            if (!perkListOfTier.ContainsKey(generalPerkList[i].Tier))
            {
                perkListOfTier[generalPerkList[i].Tier] = new List<Perk>();
            }
            perkListOfTier[generalPerkList[i].Tier].Add(generalPerkList[i]);
        }

        Debug.Log("count tier 3 = " + perkListOfTier[PerkTierType.Third].Count);
        return perkListOfTier;
    }
}
