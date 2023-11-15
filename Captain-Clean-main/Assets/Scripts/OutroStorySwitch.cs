using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroStorySwitch : MonoBehaviour
{
    public GameObject[] background;
    [SerializeField] private AudioSource Dialogue1;
    [SerializeField] private AudioSource Dialogue2;
   
    int index;
    [SerializeField] private AudioSource pressed;

    void Start()
    {
        Dialogue1.Play();
        index = 0;
    }


    void Update()
    {
        if (index >= background.Length)
            index = background.Length;

        if (index < 0)
            index = 0;



        if (index == 0)
        {
            background[0].gameObject.SetActive(true);
        }

    }

    public void Next()
    {
        pressed.Play();

        // Stop playing Dialogue1
        Dialogue1.Stop();

        if (index == 0)
        {
            // Play Dialogue2 on the first "Next" press
            Dialogue2.Play();
        }
        else if (index == 1)
        {
            Dialogue2.Stop();
        }

        index += 1;

        if (index >= background.Length)
        {
            // If we reached the end of the background images, load the next scene
            SceneManager.LoadScene(2);
        }
        else
        {
            // Turn off the previous background image
            if (index > 0)
            {
                background[index - 1].gameObject.SetActive(false);
            }

            // Turn on the current background image
            background[index].gameObject.SetActive(true);
        }

        Debug.Log(index);
    }

    public void Skip()
    {
        SceneManager.LoadScene(2);
    }
}
