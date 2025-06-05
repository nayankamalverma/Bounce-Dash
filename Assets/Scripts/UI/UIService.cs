using BounceDash.Scripts.Utilities;
using UnityEngine;

namespace BounceDash.Scripts.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private MainMenuUIController mainMenuUIController;
        [SerializeField] private GamePlayUIController gamePlayUIController;
        [SerializeField] private GameOverUIController gameOverUIController;

        private EventService eventService;

        public void SetServices(EventService eventService)
        {
            this.eventService = eventService;
            mainMenuUIController.SetService(eventService);
            gamePlayUIController.SetService(eventService);
            gameOverUIController.SetService(eventService);
            AddEventListeners();
        }
        private void AddEventListeners()
        {
            eventService.OnGameStart.AddListener(OnGameStart);
            eventService.OnGameOver.AddListener(OnGameOver);
            eventService.OnMainMenuButtonClicked.AddListener(OnMainMenuButtonClick);
        }

        private void OnMainMenuButtonClick()
        {
            DisableGameOverUI();
            UnableMainMenu();
        }
        private void OnGameOver(int score, int coins)
        {
            UnsableGameOverUI();
            DisableGamePlayUI();
        }

        private void OnGameStart()
        {
            DisableGameOverUI();
            DisableMainMenu();
            UnableGamePlayUI();
        }
        private void OnDestroy()
        {
            eventService.OnGameStart.RemoveListener(OnGameStart);
            eventService.OnGameOver.RemoveListener(OnGameOver);
            eventService.OnMainMenuButtonClicked.RemoveListener(OnMainMenuButtonClick);
        }


        private void UnableMainMenu()=> mainMenuUIController.gameObject.SetActive(true);
        private void DisableMainMenu()=> mainMenuUIController.gameObject.SetActive(false);
        private void UnableGamePlayUI()=> gamePlayUIController.gameObject.SetActive(true);
        private void DisableGamePlayUI()=> gamePlayUIController.gameObject.SetActive(false);
        private void UnsableGameOverUI()=> gameOverUIController.gameObject.SetActive(true);
        private void DisableGameOverUI()=> gameOverUIController.gameObject.SetActive(false);
    }
}