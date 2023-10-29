using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public static bool isGameOver;
    private int currentIndexScene;

    private int CurrentSceneIndex;
    [SerializeField] private AudioSource pressed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
   
    public  void Resume()
    {
        PlayAudioPressed();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    } 
   public void Pause()
    {
        PlayAudioPressed();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        GameisPaused = true;
    }
    public void Loadmenu()
    {
            PlayAudioPressed();
            Time.timeScale = 1f;
            currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentIndexScene);
            SceneManager.LoadScene("MainMenu");

    }

    public void QuitGame()
    {
        PlayAudioPressed();
        Debug.Log("Quit");
        Application.Quit();
    }
    public void PlayAudioPressed()
    {
        pressed.Play();
    }
    
}
