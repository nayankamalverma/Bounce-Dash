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
        [SerializeField] private Button instructionsButton;
        [SerializeField] private Button instructionsCloseButton;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private GameObject instructionPanel;

        private EventService eventService;
        private const string highScorePref = "HighScore";
        private const string coinsPref = "Coins";
        private void Awake()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
            instructionsButton.onClick.AddListener(OpenInstructionPanel);
            instructionsCloseButton.onClick.AddListener(CloseInstructionPanel);
        }

        private void CloseInstructionPanel()
        {
            instructionPanel.SetActive(false);
        }

        private void OpenInstructionPanel()
        {
            instructionPanel.SetActive(true);
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
            instructionsButton.onClick.RemoveListener(OpenInstructionPanel);
            instructionsCloseButton.onClick.RemoveListener(CloseInstructionPanel);
        }
    }
}
