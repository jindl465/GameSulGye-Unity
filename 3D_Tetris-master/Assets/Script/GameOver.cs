using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// Game over scene

public class GameOver : MonoBehaviour {

    public GUISkin skin;

    void OnGUI()
    {
        // Create back button and if back button pressed
        if (GUI.Button(new Rect((Screen.width * 0.10f), (Screen.height * 0.75f), (Screen.width * 0.10f), 100), "Back to Menu", skin.button)) 
        {
            // Goto main menu
            SceneManager.LoadScene("MainMenu");
        }
        // Create restart button and if restart button pressed
        if (GUI.Button(new Rect((Screen.width * 0.80f), (Screen.height * 0.75f), (Screen.width * 0.10f), 100), "Restart",skin.button))
        {
            // Reset the game and restart
            Group.stage = 1;
            Group.numberOfBlocksLeft = Group.GetNumberOfBlocksForStage(Group.stage);
            SceneManager.LoadScene(1);
        }
        // Shows final score
        GUI.Box(new Rect(100, (Screen.height * 0.02f), 100, 100), "Total Score: \n" + Grid.lastGameScore.ToString(), skin.box);
    }
}
