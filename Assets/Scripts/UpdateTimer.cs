using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    public UIManager uiManager; // Reference the ui manager

    // Start is called before the first frame update
    void Start()
    {
        // Get the time survived from the data manager and update the final time survived
        GameDataManager gameDataManager = GameDataManager.Instance;
        uiManager.UpdateFinalTimer(gameDataManager.timeSurvived);
        Cursor.visible = true; // Show the cursor
        Cursor.lockState = CursorLockMode.None; // Unlock the mouse
    }
}