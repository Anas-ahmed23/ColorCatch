using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private bool gameOverTriggered = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!gameOverTriggered && player != null)
            agent.SetDestination(player.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!gameOverTriggered && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy touched player — GAME OVER");
            gameOverTriggered = true;

            // Stop movement
            agent.isStopped = true;

            // Trigger your game over logic
            GameManager.Instance.EndGame();
        }
    }
}
