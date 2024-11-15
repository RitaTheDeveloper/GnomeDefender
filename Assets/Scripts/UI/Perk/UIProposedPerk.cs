using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProposedPerk : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTxt;
    [SerializeField] private TextMeshProUGUI _valueTxt;
    [SerializeField] private TextMeshProUGUI _tierTxt;
    [SerializeField] private Image _backgroundImg;
    [SerializeField] private Button _selectPerkBtn;

    public void Init(Perk perk, UIPerkController uIPerkController, PerkTierStruct tierStruct)
    {
        _nameTxt.text = perk.Title;
        _valueTxt.text = perk.Value.ToString();
        int tier = (int)perk.Tier;
        _tierTxt.text = tierStruct.PerkTierDataStruct[tier].TierString;
        _backgroundImg.color = tierStruct.PerkTierDataStruct[tier].TierColor;
        _selectPerkBtn.onClick.RemoveAllListeners();
        _selectPerkBtn.onClick.AddListener(perk.AddPerk);
        _selectPerkBtn.onClick.AddListener(uIPerkController.ClosePerkMenu);
    }
}
