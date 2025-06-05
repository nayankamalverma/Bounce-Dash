using BounceDash.Scripts.Utilities;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;

    private EventService eventService;
    private const string highScorePref = "HighScore";
    private const string coinsPref = "Coins";

    private void Awake()
    {
        restartButton.onClick.AddListener(Restart);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void SetService(EventService eventService)
    {
        this.eventService = eventService;
        AddEventListeners();
    }

    private void AddEventListeners()
    {
        eventService.OnGameOver.AddListener(UpdatePanel);
    }

    private void UpdatePanel(int score, int coinsCollected)
    {
        UpdateTexts(score, coinsCollected);
        int highScore = PlayerPrefs.GetInt(highScorePref);
        int coins = PlayerPrefs.GetInt(coinsPref);
        if (score > highScore)
        {
            PlayerPrefs.SetInt(highScorePref,score);
        }
        PlayerPrefs.SetInt(coinsPref, coins+coinsCollected);
    }

    private void UpdateTexts(int score, int coins)
    {
        scoreText.text= "Score: "+ score;
        coinText.text = "Coins Collected: "+ coins;
    }

    private void Restart()
    {
        eventService.OnGameStart.Invoke();
    }

    private void MainMenu()
    {
        eventService.OnMainMenuButtonClicked.Invoke();
    }

    private void OnDestroy()
    {
        eventService.OnGameOver.RemoveListener(UpdatePanel);
    }
}
