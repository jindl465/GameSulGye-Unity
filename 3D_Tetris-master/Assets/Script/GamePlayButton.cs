using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

// Actions for buttons in game play

public class GamePlayButton : MonoBehaviour
{
    public GUISkin skin;

    public static bool isPaused;
    public bool isGameOver;
    private Animator anim;
    public Texture pause;
    public Texture mute;
    public Texture play;
    public Texture origin;
    public Canvas pauseScene;
    public Canvas clearScene;
    public AudioSource bg_music;
    public static bool musicMute = true;
    private Texture musicButton;
    public Camera mainCamera;

    void Start()
    {
        //initialize BGM and pauseScene
        bg_music.mute = musicMute;

        if (musicMute)
        {
            musicButton = mute;
        }
        else
        {
            musicButton = play;
        }

        //Make event popup screen to invisible
        pauseScene.enabled = false;
        clearScene.enabled = false;
    }

    void OnGUI()
    {
        //Menu button
        if (GUI.Button(new Rect((Screen.width - 100), (Screen.height * 0.02f), 70, 60), "Menu", skin.button)) 
        {
            //Goto main menu
            isPaused = false;
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
        //Restart button
        if (GUI.Button(new Rect((Screen.width - 190), (Screen.height * 0.02f), 70, 60), "Restart", skin.button)) 
        {
            //Reset the game
            Grid.gameScore = 0;
            Group.stage = 1;
            Group.numberOfBlocksLeft = Group.GetNumberOfBlocksForStage(Group.stage);
            isPaused = false;
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //Pause button
        if (GUI.Button(new Rect((Screen.width - 280), (Screen.height * 0.02f), 70, 60), pause, skin.button)) 
        {
            //Toggle pause button
            isPaused = !isPaused;
            if (isPaused == true)
            {
                //Stop time
                Time.timeScale = 0;
                pauseScene.enabled = true;
            }
            else
            {
                //Restart time
                Time.timeScale = 1;
                pauseScene.enabled = false;
            }
        }
        //Mute button
        if (GUI.Button(new Rect((Screen.width - 370), (Screen.height * 0.02f), 70, 60), musicButton, skin.button))
        {
            //Toggle mute button
            musicMute = !musicMute;
            //Change music state
            bg_music.mute = musicMute;
            if (musicMute)
            {
                musicButton = mute;
            }
            else
            {
                musicButton = play;
            }
        }

        //Game Score display
        GUI.Box(new Rect((Screen.width * 0.02f), (Screen.height * 0.02f), 100, 100), "Stage " + Group.stage.ToString(), skin.box);
        GUI.Box(new Rect((Screen.width * 0.02f), (Screen.height * 0.02f) + 40, 100, 200), "Total Score: " + Grid.gameScore.ToString(), skin.box);
        GUI.Box(new Rect((Screen.width * 0.02f), (Screen.height * 0.02f) + 80, 100, 200), "Blocks Left: " + Group.numberOfBlocksLeft.ToString(), skin.box);

        //Complete the stage
        if (Group.numberOfBlocksLeft <= 0)
        {
            // stop the game
            Time.timeScale = 0;
            Grid.lastGameScore = Grid.gameScore;
            // show stage clear message
            clearScene.enabled = true;
        }
    }
}
