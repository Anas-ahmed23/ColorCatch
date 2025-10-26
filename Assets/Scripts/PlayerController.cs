using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;   // Movement speed

    private Rigidbody rb;          // Rigidbody reference
    private Vector3 moveInput;     // Stores movement input

    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get horizontal and vertical inputs (WASD / Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Create a direction vector from input
        moveInput = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void FixedUpdate()
    {
        // Move the player using physics (Rigidbody)
        Vector3 moveVelocity = moveInput * moveSpeed;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        Collectible c = other.GetComponent<Collectible>();
        if (c != null)
        {
            // ✅ Play collect sound
            if (c.collectSound != null)
                AudioSource.PlayClipAtPoint(c.collectSound, transform.position);

            // ✅ Spawn particle effect BEFORE destroying collectible
            if (GameManager.Instance.collectEffectPrefab != null)
                Instantiate(GameManager.Instance.collectEffectPrefab, other.transform.position, Quaternion.identity);

            // ✅ Get collectible color
            Color collectedColor = c.GetComponent<Renderer>().material.color;

            // ✅ Check if it matches target
            if (collectedColor == GameManager.Instance.targetColor)
            {
                GameManager.Instance.AddScore(1);
            }
            else
            {
                GameManager.Instance.AddScore(-1);
            }

            // ✅ Destroy collectible and set new target
            Destroy(other.gameObject);
            GameManager.Instance.SetRandomTargetColor();
        }
    }



}


