using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScriptTest : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

  
}
