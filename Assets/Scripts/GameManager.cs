using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer; // Timer to keep track how long the player survived
    public UIManager uiManager; // Reference to the ui manager
    public SceneChanger sceneChanger; // Reference to the scene changer

    // Update is called once per frame
    void Update()
    {
        // Update the time
        timer += Time.deltaTime;
        uiManager.UpdateTimer(timer);
        if (timer >= 360)
        {
            Cursor.lockState = CursorLockMode.None; // Unlock the mouse
            Cursor.visible = true; // Unhide the cursor
            sceneChanger.MoveToScene(3); // Move to good end scene
        }
    }

    // Function to update the health of the slider
    public void ReportHealth(int health, int maxHealth)
    {
        uiManager.SetHealth(health, maxHealth);
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None; // Unlock the mouse
            Cursor.visible = true; // Unhide the cursor
            sceneChanger.MoveToScene(2); // Move to bad end scene
        }
    }

    // Function to set the health of the slider
    public void SetUpHealth()
    {
        uiManager.SetMaxHealth();
    }
}
