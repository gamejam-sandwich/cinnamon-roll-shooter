using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Processors;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    public float currentHealth;
    [SerializeField]
    public float maxHealth;

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

            if (gameObject.tag == "Player")
            {
                GameObject obj = ButtonBehaviours.FindObjectByName("ReplayBtn");
                obj.SetActive(true);
            }
            OnDied.Invoke();
        }
        else
        {
            AudioManager am = Util.FindObjectByName("AudioManager").GetComponent<AudioManager>();
            am.PlaySFX(am.splat);
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
