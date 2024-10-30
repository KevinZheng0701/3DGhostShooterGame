using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer ui
    public TextMeshProUGUI finalTimerText; // Final timer ui
    public Slider healthBar;

    // Function to update the timer in the game scene
    public void UpdateTimer(float time)
    {
        timerText.text = "Time: " + Mathf.Round(time).ToString();
    }

    // Function to update the time survived in the end scene
    public void UpdateFinalTimer(float time)
    {
        finalTimerText.text = "You survived for " + Mathf.Round(time).ToString() + " seconds!";
    }

    // Set the max health to a certain value
    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health; // Set the max health 
        healthBar.value = health; // Set the health to the max
    }

    // Set the health bar to a certain value
    public void SetHealth(int health)
    {
        healthBar.value = health; // Set the health
    }
}
