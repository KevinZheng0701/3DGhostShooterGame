using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer; // Timer to keep track how long the player survived
    public UIManager uiManager; // Reference to the ui manager
    public SceneChanger sceneChanger; // Reference to the scene changer
    public GameDataManager gameDataManager;

    // Update is called once per frame
    void Update()
    {
        // Update the time
        timer += Time.deltaTime;
        uiManager.UpdateTimer(timer);
    }

    public void ReportHealth(int health)
    {
        uiManager.SetHealth(health);
        if (health <= 0)
        {
            gameDataManager.timeSurvived = timer;
            sceneChanger.MoveToScene(2);
        }
    }

    public void SetUpHealth(int health)
    {
        uiManager.SetMaxHealth(health);
    }
}
