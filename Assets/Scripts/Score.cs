using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    private float score = 0.0f;

    private int LevelSpeed = 1;
    private int ScoreToIncreaseSpeed = 10;

    private bool isDead = false;
    public Text scoreText;
    public DeathMenu deathMenu;
    public GameObject scoreObject;

    void Start()
    {
        scoreObject = GameObject.FindGameObjectWithTag("Score");
        scoreObject.SetActive(true);
    }
    // Update is called once per frame
    void Update ()
    {
        if (isDead)
            return;

        if (score >= ScoreToIncreaseSpeed)
        {
            SpeedUp();
        }

        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString(); // Convert float to int to avoid decimal

        
    }

   void SpeedUp()
    {
        ScoreToIncreaseSpeed += 10; // The next Speed up will be after evey 10 points
        LevelSpeed++;

        GetComponent<PlayerMovement>().SetSpeed(LevelSpeed); // Gets data from Player movement script
    }

    public void OnDeath()
    {
        isDead = true;
        if (PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
        scoreObject.SetActive(false);
        deathMenu.ToggleEndMenu(score);
    }
}
