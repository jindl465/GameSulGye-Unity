﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// Actions in main menu

public class MenuScript : MonoBehaviour {

    public Canvas QuitMenu;
    public Canvas GuideMenu;
    public Canvas SettingMenu;
    public Button StartButton;
    public Button ExitButton;
    public Button GuideButton;
    public Button SettingButton;
    public Toggle MenuMute;
    public Toggle GameMute;
    public Slider Difficulty;

    public AudioSource menu_music;    
    
	// Use this for initialization
	void Start () {
        QuitMenu = QuitMenu.GetComponent<Canvas>();
        GuideMenu = GuideMenu.GetComponent<Canvas>();
        SettingMenu = SettingMenu.GetComponent<Canvas>();
        StartButton = StartButton.GetComponent<Button>();
        ExitButton = ExitButton.GetComponent<Button>();
        GuideButton = GuideButton.GetComponent<Button>();
        SettingButton = SettingButton.GetComponent<Button>();
        MenuMute = MenuMute.GetComponent<Toggle>();
        GameMute = GameMute.GetComponent<Toggle>();

        //Initialize popup menus
        QuitMenu.enabled = false;
        GuideMenu.enabled = false;
        SettingMenu.enabled = false;

        Difficulty.value = Group.gameDifficulty;
        //initialize the BGM
        menu_music.mute = !MenuMute.isOn;
    }

    void Update()
    {
        //Set game music state
        if (GamePlayButton.musicMute)
        {
            GameMute.isOn = false;
        }
        else
        {
            GameMute.isOn = true;
        }
    }
	
    //Exit pressed in main menu
    public void ExitPressed()
    {
        //Shows quit menu
        QuitMenu.enabled = true;
        GuideMenu.enabled = false;
        StartButton.enabled = false;
        SettingMenu.enabled = false;
        ExitButton.enabled = false;
        GuideButton.enabled = false;
        SettingButton.enabled = false;
    }

    //No pressed in quit menu
    public void NoPressed()
    {
        //Restore to main menu
        QuitMenu.enabled = false;
        GuideMenu.enabled = false;
        SettingMenu.enabled = false;
        StartButton.enabled = true;
        ExitButton.enabled = true;
        GuideButton.enabled = true;
        SettingButton.enabled = true;
    }

    //Yes pressed in quit menu
    public void YesPressed()
    {
        //Quit the game
        Application.Quit();
    }

    //Play button pressed in main menu
    public void startLevel()
    {
        //Start the game
        Debug.Log("PRESSED");
        Group.stage = 1;
        Group.numberOfBlocksLeft = Group.GetNumberOfBlocksForStage(Group.stage);
        SceneManager.LoadScene(1);
    }

    //How to play button pressed in main menu
    public void GuidePressed()
    {
        //Shows guide menu
        GuideMenu.enabled = true;
        QuitMenu.enabled = false;
        SettingMenu.enabled = false;
        StartButton.enabled = false;
        GuideButton.enabled = false;
        ExitButton.enabled = false;
        SettingButton.enabled = false;
    }

    //Back button pressed in guide menu
    public void BackPressed()
    {
        //Restore to main menu
        GuideMenu.enabled = false;
        QuitMenu.enabled = false;
        SettingMenu.enabled = false;
        StartButton.enabled = true;
        ExitButton.enabled = true;
        GuideButton.enabled = true;
        SettingButton.enabled = true;
    }

    //Setting button pressed in main menu
    public void SettingPressed()
    {
        //Show setting menu
        SettingMenu.enabled = true;
        GuideMenu.enabled = false;
        QuitMenu.enabled = false;
        StartButton.enabled = false;
        ExitButton.enabled = false;
        GuideButton.enabled = false;
        SettingButton.enabled = false;
    }

    //Back button pressed in setting menu
    public void S_backPressed()
    {
        //Restore to main menu
        GuideMenu.enabled = false;
        QuitMenu.enabled = false;
        SettingMenu.enabled = false;
        StartButton.enabled = true;
        ExitButton.enabled = true;
        GuideButton.enabled = true;
        SettingButton.enabled = true;
    }

    //Toggle menu music state
    public void MenuToggle()
    {
        if(MenuMute.isOn == true)
        {
            menu_music.mute = false;
            
        }
        else
        {
            menu_music.mute = true;
        }
    }

    //Toggle game music state
    public void GameToggle()
    {
        if(GameMute.isOn == true)
        {
            GamePlayButton.musicMute = false;
        }
        else
        {
            GamePlayButton.musicMute = true;
            Debug.Log("pressed");
        }

    }

    //Change difficulty of the game
    public void ChangeDifficulty()
    {
        Group.gameDifficulty = (int)Difficulty.value;
    }
}
