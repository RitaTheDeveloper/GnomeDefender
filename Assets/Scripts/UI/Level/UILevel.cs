using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevel : MonoBehaviour
{
    [SerializeField] private Slider _levelSlider;
    [SerializeField] private TextMeshProUGUI _lvlTxt;

    public void DisplayLevel(int currentLevel, float expPercentage)
    {
        _lvlTxt.text = "LV: " + currentLevel.ToString();
        _levelSlider.value = expPercentage;
    }
}
