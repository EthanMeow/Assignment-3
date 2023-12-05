using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other.CompareTag("Player"))
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
