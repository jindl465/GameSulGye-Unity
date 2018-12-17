using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowSliderValue : MonoBehaviour {

    public Text Difficulity;
	// Use this for initialization
	void Update () {
        // Update difficultiy for this game (increase block falling speed)
        Difficulity.text = Group.gameDifficulty.ToString();
	}
}
