using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelController : MonoBehaviour
{
    [SerializeField] private PlayerLevelController playerLevelController;
    [SerializeField] private UILevel UILevel;

    private void OnEnable()
    {
        playerLevelController.OnAddExp += DisplayLevel;
    }

    private void OnDisable()
    {
        playerLevelController.OnAddExp -= DisplayLevel;
    }

    private void Start()
    {
        UILevel.DisplayLevel(1, 0);
    }

    private void DisplayLevel()
    {
        float expPercent = playerLevelController.CurrentExp / playerLevelController.ExpNeededForLevelUp;
        UILevel.DisplayLevel(playerLevelController.CurrentLevel, expPercent);
    }
}
