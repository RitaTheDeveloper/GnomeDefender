using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthController : MonoBehaviour
{
    public Health health;
    public UIHealth uiHealth;

    private void Update()
    {
        if (uiHealth)
        {
            uiHealth.DisplayHealth((int)health.StartHealth, (int)health.CurrentHealth);
        }
    }

    public void Init(UIHealth uIHealth)
    {
        this.uiHealth = uIHealth;
    }

    private void OnDestroy()
    {
        if (uiHealth)
            uiHealth.DisplayHealth((int)health.StartHealth, 0);
    }
}
