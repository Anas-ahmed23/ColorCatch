using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy caught the player!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart scene
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enemy caught the player! (Trigger)");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
