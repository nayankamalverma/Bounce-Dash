using UnityEngine;
using UnityEngine.InputSystem;

namespace BounceHigher.Script.Player
{
    public class PlayerController : MonoBehaviour
    {

        [Header("Movement")] [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float desiredHeight = 3f; // Max bounce height
        [Header("Input")] private PlayerInput playerInput;

        private InputAction m_moveAction;
        private Vector2 moveInput;
        private Rigidbody2D rb;
        private bool isBouncing;

        private void Awake()
        {
            playerInput = new PlayerInput();
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            // Initial drop
            rb.linearVelocity = new Vector2(0, -Mathf.Sqrt(2f * Mathf.Abs(Physics2D.gravity.y) * desiredHeight));
        }

        private void OnEnable() => playerInput.Enable();
        private void OnDisable() => playerInput.Disable();

        private void Update()
        {
            moveInput = playerInput.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground") && !isBouncing)
            {
                isBouncing = true;
                rb.linearVelocity = new Vector2(0, Mathf.Sqrt(2f * Mathf.Abs(Physics2D.gravity.y) * desiredHeight));
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            isBouncing = false;
        }
    }
}