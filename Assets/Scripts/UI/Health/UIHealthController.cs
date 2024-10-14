using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthController : MonoBehaviour
{
    public Health health;
    public UIHealth uiHealth;

    private void Update()
    {
        uiHealth.DisplayHealth((int)health.StartHealth, (int)health.CurrentHealth);
    }
}
