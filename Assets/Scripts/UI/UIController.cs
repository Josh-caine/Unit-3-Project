using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    private HealthSystem playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start() 
    {
        playerHealth = PlayerInput.Instance.GetComponent<HealthSystem>();
        playerHealth.OnLifeChanged += UpdateHealthText;
        playerHealth.OnDead += DisplayDeathScreen;
    }

    void DisplayDeathScreen()
    {
        // Set Active
    }


    void UpdateHealthText(float healthToDisplay)
    {
        healthText.text = "Health: " +healthToDisplay.ToString("F2");
    }
}
