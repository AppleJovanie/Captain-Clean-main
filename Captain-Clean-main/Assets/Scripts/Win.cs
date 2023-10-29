using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    private void Start()
    {
        // Initially, set the UI element as inactive
        gameObject.SetActive(false);
    }

    // Call this method to activate the UI element
    public void ShowUI()
    {
        gameObject.SetActive(true);
    }
}