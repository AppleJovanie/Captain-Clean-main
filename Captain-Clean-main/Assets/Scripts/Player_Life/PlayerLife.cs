using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Vector3 respawnPoint;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public string[] destroyOnCollisionTags = { "HeadLice", "Scabies", "AthleteFoot", "Cavity", "Impetigo" };
    public string[] Bosses = { "BossLice", "Impetaigor", "Galisorous", "Alifungor", "CavityBoss" };
    public string[] trapses = { "Trap" };
    [SerializeField] private AudioSource die;
    private CoinCollectorScript coinCollectorScript;
    [SerializeField] private AudioSource checkPoint;
    private bool checkpointReached = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coinCollectorScript = FindObjectOfType<CoinCollectorScript>();
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
            Respawn();
        }
        else if (ArrayContains(trapses, traps))
        {
            Die();
            Respawn();
        }
        else if (ArrayContains(Bosses, boss))
        {
            Die();
            Respawn();

            if (HealthManager.health <= 0)
            {
                RestartGame();
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
        if (collision.CompareTag("Checkpoint") || collision.CompareTag("HeadLice"))
        {
            respawnPoint = transform.position;
        }
        if (collision.CompareTag("Checkpoint") && !checkpointReached)
        {
            checkpointReached = true;
            respawnPoint = transform.position;

            checkPoint.Play();
            PlayerPrefs.SetInt("CheckpointReached", 1);
            PlayerPrefs.Save();
        }
    }

    private void Respawn()
    {
        checkPoint.Stop();
        StartCoroutine(BecomeImmune(1f));
        transform.position = respawnPoint;

        coinCollectorScript.HandleRespawn();
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

        if (HealthManager.health <= 0)
        {
            anim.SetTrigger("death");
        }
    }

    private IEnumerator BecomeImmune(float immunityDuration)
    {
      
        yield return new WaitForSeconds(immunityDuration);
      
    }
}
