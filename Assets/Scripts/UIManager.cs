using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer ui
    public Image healthBar; // Image for the health bar

    // Function to update the timer in the game scene
    public void UpdateTimer(float time)
    {
        int hours = Mathf.FloorToInt(time / 60);
        int minutes = Mathf.FloorToInt(time % 60);
        if (hours == 0)
        {
            hours = 12;
        }
        timerText.text = string.Format("{0:00}:{1:00} AM", hours, minutes);
    }

    // Set the max health to a certain value
    public void SetMaxHealth()
    {
        healthBar.fillAmount = 1;
    }

    // Set the health bar to a certain value
    public void SetHealth(int health, int maxHealth)
    {
        float percentage = (float)health / (float)maxHealth;
        healthBar.fillAmount = percentage;
    }
}
