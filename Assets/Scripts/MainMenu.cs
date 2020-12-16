using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Text highscoreText;

	// Use this for initialization
	void Start ()
    {
        highscoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString(); // Highscore is saved using PlayerPrefs
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Function of Game button
    public void toGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Function of Exit button
    public void onExit()
    {
        Application.Quit();
    }
}
