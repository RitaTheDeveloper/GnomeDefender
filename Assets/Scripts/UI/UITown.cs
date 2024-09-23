using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITown : MonoBehaviour
{
    public Health health;
    public UIHealth uiHealth;

    private void Update()
    {
        uiHealth.DisplayHealth(health.StartHealth, health.CurrentHealth);
    }
}
