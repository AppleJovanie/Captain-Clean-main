using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    private Collider2D playerCollider;

    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    public void DisableCollider()
    {
        playerCollider.enabled = false;
    }

    public void EnableCollider()
    {
        playerCollider.enabled = true;
    }
}
