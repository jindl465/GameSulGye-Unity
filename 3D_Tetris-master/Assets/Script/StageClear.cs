using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour {
    
    public Text Message;

    // Use this for initialization
    void Start()
    {
        Message.text = "STAGE " + Group.stage.ToString() + " CLEAR!";
    }

    public void OnNextButtonClick()
    {
        Grid.gameScore = 0;
        Group.stage++;
        Group.numberOfBlocksLeft = Group.GetNumberOfBlocksForStage(Group.stage);
        SceneManager.LoadScene(1);
    }

    public void OnMainButtonClick()
    {
        Grid.gameScore = 0;
        Group.stage = 0;
        Group.numberOfBlocksLeft = 0;
        SceneManager.LoadScene(0);
    }
}
