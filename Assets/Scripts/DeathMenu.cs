using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathMenu : MonoBehaviour
{
    // Instantiate objects
    public Text scoreText;
    public Image backgroundImage;

    public bool isShown = false; // Bool to check if Death menu is hidden

    public float transition = 0.0f;
    // Use this for initialization
    void Start ()
    {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If it isn't shown, then return to update.
        if (!isShown)
            return;

        //transition of Death menu after activated
        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color (0,0,0,0), Color.black, transition);
	}

    // Toggle the death menu
    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShown = true;
    }

    // Function of Restart button
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function of Menu button
    public void toMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
}
