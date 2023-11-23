using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maxHealth;

    public float healthLeft
    {
        get
        {
            return currentHealth/maxHealth;
        }
    }
    public bool isInvincible { get; set; }
    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damageAmt)
    {
        if(currentHealth == 0 || isInvincible)
        {
            return;
        }

        currentHealth -= damageAmt;
        OnHealthChanged.Invoke();

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float addAmt)
    {
        if(currentHealth == maxHealth)
        {
            return;
        }

        currentHealth += addAmt;
        OnHealthChanged.Invoke();

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
