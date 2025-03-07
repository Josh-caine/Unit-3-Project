using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HealthSystem : MonoBehaviour
{
    public GameObject player;
    public float currentHealth;
    [SerializeField] private float maxHealth;

    public Action<float> OnLifeChanged;
    public Action OnDead;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void IncreaseHealth(float toIncrease)
    {
        currentHealth += toIncrease;
        OnLifeChanged?.Invoke(currentHealth);
    }

    public void DecreaseHealth(float toDecrease)
    {
        currentHealth -= toDecrease;
        OnLifeChanged?.Invoke(currentHealth);

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(currentHealth <= 0)
        {
            OnDead?.Invoke();
        }
    }



}
