using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public int damage = 10;

    private void Update()
    {
        // Ensure player and enemy are not null
        if (player == null)
        {
            Debug.LogError("Player not assigned to the enemy.");
            return;
        }

        // Move the enemy towards the player
        transform.LookAt(player);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        // Check if the collided object is the player
        if (other.CompareTag("Player"))
        {
            // Reduce player's health

            Debug.Log("OnTriggerEnter - Player");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce player's health

            Debug.Log("OnTriggerEnter - Player");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
   
}
