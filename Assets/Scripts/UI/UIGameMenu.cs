using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeTxt;

    private Color _startTimeColor;

    private void Awake()
    {
        _startTimeColor = _timeTxt.color;
    }

    public void ShowTime(float currentTime)
    {
        // string timeString = string.Format("{0:00}:{1:00}", (Mathf.CeilToInt(currentTime) / 60), (Mathf.CeilToInt(currentTime) % 60));
        int time = Mathf.CeilToInt(currentTime);
        if (time < 6)
        {
            _timeTxt.color = Color.red;
        }
        else
        {
            _timeTxt.color = _startTimeColor;
        }

        _timeTxt.text = time.ToString();
    }
}
