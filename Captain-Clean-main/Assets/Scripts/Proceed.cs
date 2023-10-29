using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proceed : MonoBehaviour
{
    [SerializeField] private AudioSource finish;
   
    public void ProceedAfterBoss()
    {
        SceneManager.LoadScene("Level2");
    }
    public void ProceedAfterImpetaigor()
    {
        SceneManager.LoadScene("Level3");
    }
    public void ProceedAfterGalisorous()
    {
        SceneManager.LoadScene("Level4");
    }
    public void ProceedAfterAlifungor()
    {
        SceneManager.LoadScene("Level5");
    }
    public void ProceedAfterCavityBoss()
    {
     
        SceneManager.LoadScene("Minigame");
    }

   
}
