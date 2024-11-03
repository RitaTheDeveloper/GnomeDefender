using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPerkController : MonoBehaviour
{
    [SerializeField] private PerkStorage _perkStorage;
    [SerializeField] private Transform _panelOfProposedPerks;
    [SerializeField] private GameObject _proposedPerkPrefab;

    private GameManager _gameManager;

    private void Start()
    {
        CreateProposedPerks(_perkStorage.GetProposedPerksList());
    }

    public void Init(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void CreateProposedPerks(List<Perk> perks)
    {
        DestroyAllSlots();
        for (int i = 0; i < perks.Count; i++)
        {
            var perk = Instantiate(_proposedPerkPrefab, _panelOfProposedPerks);
            perk.GetComponent<UIProposedPerk>().Init(perks[i], this);
        }
    }

    private void DestroyAllSlots()
    {
        foreach (Transform child in _panelOfProposedPerks)
        {
            Destroy(child.gameObject);
        }
    }

    public void ClosePerkMenu()
    {        
        _gameManager.GetComponent<TimeController>().ContinueTime();
        CreateProposedPerks(_perkStorage.GetProposedPerksList());
        this.gameObject.SetActive(false);
    }
}
