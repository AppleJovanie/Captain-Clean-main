using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpenerStory : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private AudioSource dialogue1;
    [SerializeField] private BedSceneStory dialogueManager;

    public void OpenPanel()
    {
        dialogue1.Play();
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
       
    }

    public void ClosePanel()
    {
        
        if (panel != null)
        {

            panel.SetActive(false);
        }
    }
}
