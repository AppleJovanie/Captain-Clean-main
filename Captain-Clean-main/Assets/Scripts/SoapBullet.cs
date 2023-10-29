using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoapBullet : MonoBehaviour
{
    public float life = 3;
    public int bulletsToDestroyBosses = 10;
    private int bulletsHitCount = 0;
    public string[] BossForSoapBullet = { "Impetaigor", "AthleteFoot", "Galisorous", "Alifungor" };
    public string[] NormalEnemies = { "Impetigo", "Scabies" };
    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string Bosses = collision.gameObject.tag;
        string normalEnemies = collision.gameObject.tag;

        // Normal Enemy In Levels
        if (ArrayContains(NormalEnemies, normalEnemies)) {

          
            Destroy(collision.gameObject);
            ScoreScript.scoreValue += 10;
        }

        // Boss for Soap Bullet
        else if  (ArrayContains(BossForSoapBullet, Bosses))
        {
            bulletsToDestroyBosses++;
            if(bulletsToDestroyBosses>= bulletsHitCount)
            {
                DestroyBoss();
            }
        }

        Destroy(gameObject);

    }
    private void DestroyBoss()
    {
        Destroy(gameObject);
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

}
