using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Vector3 pointB;  // the end position
    public float speed = 2f;
    private Vector3 pointA;
    private bool movingToB = true;

    void Start()
    {
        pointA = transform.position; // starting point
    }

    void Update()
    {
        // Choose target
        Vector3 target = movingToB ? pointB : pointA;

        // Move towards it
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Switch direction when reaching a point
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }
}
