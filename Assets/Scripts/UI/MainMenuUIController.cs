using UnityEngine;
using UnityEngine.UI;
using BounceDash.Scripts.Utilities;
using TMPro;
using Unity.VisualScripting;

namespace  BounceDash.Scripts.UI
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button inventoryButton;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private EventService eventService;
        private const string highScorePref = "HighScore";
        private const string coinsPref = "Coins";
        private void Awake()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnEnable()
        {
            highScoreText.text = "HighScore: " + PlayerPrefs.GetInt(highScorePref, 0);
            coinText.text = "Coins: " + PlayerPrefs.GetInt(coinsPref, 0);
        }

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
        }

        private void OnPlayButtonClicked()
        {
            eventService.OnGameStart.Invoke();
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }
    }
}
