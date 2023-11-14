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

    private bool isImmune = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    }

    private void Respawn()
    {
        StartCoroutine(BecomeImmune(2f));
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

        if (HealthManager.health <= 0)
        {
            anim.SetTrigger("death");
        }
    }

    private IEnumerator BecomeImmune(float immunityDuration)
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityDuration);
        isImmune = false;
    }
}
