using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Vector3 respawnPoint;
    private Animator anim;
    private Rigidbody2D rb;

    public string[] destroyOnCollisionTags = { "HeadLice", "Scabies", "AthleteFoot", "Cavity", "Impetigo" };
    public string[] Bosses = { "BossLice", "Impetaigor", "Galisorous", "Alifungor", "CavityBoss" };
    public string[] trapses = { "Trap" };
    [SerializeField] private AudioSource die;
  
    
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();        
        respawnPoint = transform.position;
        anim=GetComponent<Animator>();  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        string boss = collision.gameObject.tag;
        string traps = collision.gameObject.tag;
      

        if (ArrayContains(destroyOnCollisionTags, tag))
        {
            Die();
            Destroy(collision.gameObject);
        }
        else if (ArrayContains(trapses, traps))
        {
            Die();
            Respawn();
        }
        else if (ArrayContains(Bosses, boss))
        {

            Die();
            if (HealthManager.health <= 0)
            {
               RestartGame();
            }
            else
            {
                Respawn();
            }
        }
    }

    private bool ArrayContains(string[] array, string value)
    {
        foreach (string item in array)
        {
            if (item == value)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint")|| collision.CompareTag("HeadLice"))
        {
            respawnPoint = transform.position;
        }
       
    }

    private void Respawn()
    {
        transform.position = respawnPoint;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Die()
    {
        die.Play();
        HealthManager.health--;
        HealthManager.Instance.UpdateHealthBar();
        
        if(HealthManager.health <=0)
        {
            anim.SetTrigger("death");
          
        }
      
    }
}
