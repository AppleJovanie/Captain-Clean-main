using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public GameObject[] background;
    public GameObject PrevButton;
    public GameObject NextButton;

    int index;

    void Start()
    {
        PrevButton.SetActive(false);
        index = 0;
    }

    void Update()
    {
        if (index >= 6)
            index = 6;

        if (index < 0)
            index = 0;
        
        if (index == 0)
        {
            background[0].gameObject.SetActive(true);
        }

        // Disable PrevButton when the panel is shown
        if (index == 0)
        {
            PrevButton.SetActive(false);
        }
    }

    public void Next()
    {
        PrevButton.SetActive(true);
        index += 1;

        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }

        // Disable NextButton when reaching the end of the index
        if (index == background.Length - 1)
        {
            NextButton.SetActive(false);
        }
    }

    public void Previous()
    {
        index -= 1;

        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }

        // Enable NextButton when going back
        NextButton.SetActive(true);

        // Disable PrevButton when reaching the start of the index
        if (index == 0)
        {
            PrevButton.SetActive(false);
        }
    }
}
