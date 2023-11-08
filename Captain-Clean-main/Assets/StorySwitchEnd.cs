using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySwitchEnd : MonoBehaviour
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
        index += 1;
        bool sceneChecker = index == background.Length;



        if (index == background.Length)
        {
            //Debug.Log(sceneChecker);
            SceneManager.LoadScene(0);
        }
        else
        {
            background[index].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
        Debug.Log(index);
    }

   

}
