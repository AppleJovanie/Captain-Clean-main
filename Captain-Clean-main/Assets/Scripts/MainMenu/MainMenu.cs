using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject continueButton;
    private bool checkpointReached = false;
    private int sceneToContinue;
    private void Start()
    {
        bool checkpointReached = PlayerPrefs.GetInt("CheckpointReached", 0) == 1;

        // Set the "Continue" button's visibility based on whether a checkpoint has been reached
        continueButton.SetActive(checkpointReached);
    }

    public void NewGame()
    {
     
        continueButton.SetActive(false); // Set the "Continue" button to not visible
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Continue()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue != 0)
            SceneManager.LoadScene(sceneToContinue);
        else
            return;

    }
}


