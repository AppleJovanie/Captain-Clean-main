using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySwitch : MonoBehaviour
{

    public GameObject[] background;
    int index;
    [SerializeField] private AudioSource pressed;

    void Start()
    {
        index = 0;
    }


    void Update()
    {
        if (index >= 4)
            index = 4;

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
        index += 1;

        //for (int i = 0; i < background.Length; i++)
        //{
        //    background[i].gameObject.SetActive(false);
        //    background[index].gameObject.SetActive(true);

        //}
        if (index == background.Length) 
        {
           
            Debug.Log("out of index");
            SceneManager.LoadScene(2);
                
        }
        else
        {
            background[index].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }

    }

    public void Skip()
    {
        SceneManager.LoadScene(1);
    }

  
}
