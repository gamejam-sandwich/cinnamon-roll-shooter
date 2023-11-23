using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarFg;

    public void UpdateHealthBar(HealthController hc)
    {
        healthBarFg.fillAmount = hc.healthLeft;
    }
}
