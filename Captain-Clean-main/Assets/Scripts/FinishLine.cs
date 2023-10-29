using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private AudioSource finish;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finish.Play();
            CompleteLevel();
        }
        
    }
    public void CompleteLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if there is a scene to proceed to
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Proceed to the next scene (increment the build index)
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // Handle what to do when there are no more scenes to proceed to
            SceneManager.LoadScene(0);
        }
    }
}
