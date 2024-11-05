using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timer; // Timer to keep track how long the player survived
    public UIManager uiManager; // Reference to the ui manager
    public SceneChanger sceneChanger; // Reference to the scene changer

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        uiManager.UpdateTimer(timer);
        // Check if player has survived long enough for the good ending
        if (timer >= 360)
        {
            EndGame(3); // Transition to good end scene
        }
    }

    // Update health on UI and check for game over condition
    public void ReportHealth(int health, int maxHealth)
    {
        uiManager.SetHealth(health, maxHealth);
        // Trigger game over if health reaches zero
        if (health <= 0)
        {
            EndGame(2); // Transition to bad end scene
        }
    }

    // Initialize maximum health on the UI
    public void SetUpHealth()
    {
        uiManager.SetMaxHealth();
    }

    // Handle end-game scenarios, unlocking cursor and switching scenes
    private void EndGame(int sceneIndex)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        sceneChanger.MoveToScene(sceneIndex);
    }
}
