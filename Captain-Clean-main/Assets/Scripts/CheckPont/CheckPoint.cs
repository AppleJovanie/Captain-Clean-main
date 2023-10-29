using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Store the checkpoint position and the scene name in PlayerPrefs
            PlayerPrefs.SetInt("CheckpointReached", 1);
            PlayerPrefs.SetFloat("CheckpointPositionX", transform.position.x);
            PlayerPrefs.SetFloat("CheckpointPositionY", transform.position.y);
            PlayerPrefs.SetString("LastCheckpointScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();

            Debug.Log("Checkpoint reached!");
        }
    }
}
