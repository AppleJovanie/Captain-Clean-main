using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proceed : MonoBehaviour
{
    [SerializeField] private AudioSource finish;
   
    public void ProceedAfterBoss()
    {
        SceneManager.LoadScene(4);
    }
    public void ProceedAfterImpetaigor()
    {
        SceneManager.LoadScene(6);
    }
    public void ProceedAfterGalisorous()
    {
        SceneManager.LoadScene(8);
    }
    public void ProceedAfterAlifungor()
    {
        SceneManager.LoadScene(10);
    }
    public void ProceedAfterCavityBoss()
    {
     
        SceneManager.LoadScene("Minigame");
    }

   
}
