using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProposedPerk : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTxt;
    [SerializeField] private TextMeshProUGUI _valueTxt;
    [SerializeField] private Button _selectPerkBtn;

    public void Init(Perk perk, UIPerkController uIPerkController)
    {
        _nameTxt.text = perk.Title;
        _valueTxt.text = perk.Value.ToString();
        _selectPerkBtn.onClick.RemoveAllListeners();
        _selectPerkBtn.onClick.AddListener(perk.AddPerk);
        _selectPerkBtn.onClick.AddListener(uIPerkController.ClosePerkMenu);
    }
}
