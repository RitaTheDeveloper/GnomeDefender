using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI txt;

    public void DisplayHealth(float max, float current)
    {
        slider.value = current / max;
        txt.text = current + "/" + max;
    }
}
