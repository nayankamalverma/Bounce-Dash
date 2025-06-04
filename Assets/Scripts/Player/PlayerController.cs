using System;
using BounceDash.Scripts.Utilities;
using Unity.VisualScripting;
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
        private int coin;
        private float score;
        private const string coinTag = "Coin";
        private const string obstacelTag = "Obstacle";
        private Vector2 spawnPosition;


        private EventService eventService;

        private void Awake()
        {
            playerInput = new PlayerInput();
            rb = GetComponent<Rigidbody2D>();
            spawnPosition = gameObject.transform.position;

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
            gameObject.transform.position = spawnPosition; 
            coin = 0;
            score = 0;
            playerInput.Enable();
            rb.simulated = true;

            // Initial drop
            rb.linearVelocity = new Vector2(0, -Mathf.Sqrt(2f * Mathf.Abs(Physics2D.gravity.y) * desiredHeight));
        }

        public void OnGameOver(int score, int coin)
        {
            rb.simulated = false;
            playerInput.Disable();
        }

        private void Update()
        {
            UpdateScore();
            moveInput = playerInput.Player.Move.ReadValue<Vector2>();
        }
        
        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        }

        private void UpdateScore()
        {
            score += Time.deltaTime;
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag(coinTag))
            {
                coin++;
                eventService.OnCoinCollected.Invoke();
            }
            if(collision.gameObject.CompareTag(obstacelTag))
            {
                eventService.OnGameOver.Invoke((int)Math.Floor(score),coin);
            }
        }
    }
}