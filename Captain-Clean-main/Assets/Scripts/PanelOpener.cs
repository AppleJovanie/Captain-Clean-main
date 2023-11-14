using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private AudioSource levelIntro;


    public void OpenPanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }

    public void ClosePanel()
    {
        levelIntro.Play();
        if (panel != null)
        {
           
            panel.SetActive(false);
        }
    }
}
