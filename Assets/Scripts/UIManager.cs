using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Timer ui
    public TextMeshProUGUI finalTimerText; // Final timer ui

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
}
