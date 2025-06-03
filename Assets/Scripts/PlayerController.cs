using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float desiredHeight = 3f; // Max bounce height
    
    private Rigidbody2D rb;
    private bool isBouncing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Initial drop
        rb.linearVelocity = new Vector2(0, -Mathf.Sqrt(2f * Mathf.Abs(Physics2D.gravity.y) * desiredHeight));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isBouncing)
        {
            isBouncing = true;
            // Apply upward velocity to reach desiredHeight
            rb.linearVelocity = new Vector2(0, Mathf.Sqrt(2f * Mathf.Abs(Physics2D.gravity.y) * desiredHeight));
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isBouncing = false;
    }
}