using BounceDash.Scripts.Utilities;
using UnityEngine;

namespace BounceDash.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")] [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float desiredHeight = 3f; // Max bounce height
        [Header("Input")] private PlayerInput playerInput;

        private Vector2 moveInput;
        private Rigidbody2D rb;
        private bool isBouncing;

        private EventService eventService;

        private void Awake()
        {
            playerInput = new PlayerInput();
            rb = GetComponent<Rigidbody2D>();
            
        }

        void Start()
        {
            rb.simulated = false;
        }

        public void SetServices(EventService eventService)
        {
            this.eventService = eventService;
        }

        public void OnGameStart()
        {
            playerInput.Enable();
            rb.simulated = true;
            // Initial drop
            rb.linearVelocity = new Vector2(0, -Mathf.Sqrt(2f * Mathf.Abs(Physics2D.gravity.y) * desiredHeight));
        }

        public void OnGameOver()
        {
            rb.simulated = false;
            playerInput.Disable();
        }

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