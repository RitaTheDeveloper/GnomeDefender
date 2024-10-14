using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkStorage : MonoBehaviour
{
    [SerializeField] private PerkConfig[] _perkConfigs;
    [SerializeField] private int _numberOfProposedPerks = 3;
    public List<Perk> AllPerks { get; private set; } = new List<Perk>();

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        for (int i = 0; i < _perkConfigs.Length; i++)
        {
            _perkConfigs[i].Init();
            AllPerks.Add(_perkConfigs[i]._perk);
        }
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
}
