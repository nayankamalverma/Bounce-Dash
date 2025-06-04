using System;
using BounceDash.Scripts.Utilities;
using TMPro;
using UnityEngine;

namespace BounceDash.Scripts.UI
{
    public class GamePlayUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI coinText;

        private float score;
        private int coin;
        private EventService eventService;

        private void Start()
        {
            score = 0;
            coin = 0;
        }

        private void Update()
        {
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + Math.Floor(score);
        }

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
        }

        private void OnEnable()
        {
            coin = 0;
            score = 0;
            UpdateCoinText();
            eventService.OnCoinCollected.AddListener(UpdateCoin);
        }

        private void UpdateCoin()
        {
            coin++;
            UpdateCoinText();
        }

        private void UpdateCoinText()
        {
            coinText.text = "Coins: " + coin;
        }
    }
}
