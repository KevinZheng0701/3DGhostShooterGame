using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer; // Timer to keep track how long the player survived
    public UIManager uiManager; // Reference to the ui manager

    // Update is called once per frame
    void Update()
    {
        // Update the time
        timer += Time.deltaTime;
        uiManager.UpdateTimer(timer);
    }
}
