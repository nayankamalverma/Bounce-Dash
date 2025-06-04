using UnityEngine;
using UnityEngine.UI;
using BounceDash.Scripts.Utilities;
using TMPro;

namespace  BounceDash.Scripts.UI
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button inventoryButton;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private EventService eventService;

        private void Awake()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
            highScoreText.text = "HighScore: "+ PlayerPrefs.GetInt("HighScore", 0);
            coinText.text = "Coins: "+PlayerPrefs.GetInt("Coins", 0);
        }

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
        }

        private void OnPlayButtonClicked()
        {
            eventService.OnGameStart.Invoke();
        }
    }
}
