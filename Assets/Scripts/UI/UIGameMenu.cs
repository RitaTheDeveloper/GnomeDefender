using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeTxt;
    [SerializeField] private UIPerkController _uiPerkController;
    private GnomeController _player;
    private Color _startTimeColor;

    private void Awake()
    {
        _startTimeColor = _timeTxt.color;
    }

    private void OnEnable()
    {
        if (_player)
        {
            _player.GetComponent<PlayerLevelController>().onLevelUp += OfferPerks;
        }        
    }
    private void OnDisable()
    {
        _player.GetComponent<PlayerLevelController>().onLevelUp -= OfferPerks;
    }

    public void Init(GnomeController player)
    {
        _player = player;
        _player.GetComponent<PlayerLevelController>().onLevelUp += OfferPerks;
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

    public void OfferPerks()
    {
        _uiPerkController.gameObject.SetActive(true);
    }
}
