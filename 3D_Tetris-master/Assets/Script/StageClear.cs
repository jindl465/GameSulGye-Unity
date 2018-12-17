using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Stage clear popup when number of left blocks became 0

public class StageClear : MonoBehaviour {
    
    public Text Message;

    // Use this for initialization
    void Start()
    {
        Message.text = "STAGE " + Group.stage.ToString() + " CLEAR!";
    }

    // When the next button clicked
    public void OnNextButtonClick()
    {
        // Update stage and number of blocks, then load new game
        Group.stage++;
        Group.numberOfBlocksLeft = Group.GetNumberOfBlocksForStage(Group.stage);
        SceneManager.LoadScene(1);
    }

    // When the main button clicked
    public void OnMainButtonClick()
    {
        // Reset the stage, number of blocks and game score, then load main menu
        Grid.gameScore = 0;
        Group.stage = 0;
        Group.numberOfBlocksLeft = 0;
        SceneManager.LoadScene(0);
    }
}
