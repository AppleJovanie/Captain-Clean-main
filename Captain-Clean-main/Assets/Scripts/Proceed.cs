using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proceed : MonoBehaviour
{
    [SerializeField] private AudioSource finish;
   
    public void ProceedAfterBoss()
    {
        SceneManager.LoadScene(3);
    }
    public void ProceedAfterImpetaigor()
    {
        SceneManager.LoadScene(5);
    }
    public void ProceedAfterGalisorous()
    {
        SceneManager.LoadScene(7);
    }
    public void ProceedAfterAlifungor()
    {
        SceneManager.LoadScene(9);
    }
    public void ProceedAfterCavityBoss()
    {
     
        SceneManager.LoadScene("Minigame");
    }

   
}
