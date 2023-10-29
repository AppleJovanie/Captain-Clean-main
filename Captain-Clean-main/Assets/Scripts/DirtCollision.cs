using UnityEngine;

public class DirtCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soap"))
        {
            // Destroy or hide the clothing/accessory item
            Destroy(other.gameObject);
        }
    }
}
