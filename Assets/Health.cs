using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter 1");
        // Check if the collided object is the player
        if (other.CompareTag("Enemy"))
        {
            // Reduce player's health

            Debug.Log("OnTriggerEnter - Enemy");
            PlayerHealth playerHealth = this.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter 1");
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reduce player's health

            Debug.Log("OnTriggerEnter - Enemy");
            PlayerHealth playerHealth = this.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
