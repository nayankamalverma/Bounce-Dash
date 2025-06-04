using BounceDash.Scripts.Utilities;
using UnityEngine;

namespace BounceDash.Scripts.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private MainMenuUIController mainMenuUIController;
        [SerializeField] private GamePlayUIController gamePlayUIController;

        private EventService eventService;

        public void SetServices(EventService eventService)
        {
            this.eventService = eventService;
            mainMenuUIController.SetService(eventService);
            gamePlayUIController.SetService(eventService);
        }
        private void OnEnable()
        {
            eventService.OnGameStart.AddListener(OnGameStart);
            eventService.OnGameOver.AddListener(OnGameOver);
        }

        private void OnGameOver(int score, int coins)
        {
            //gameOverUIController.gameObject.SetActive(true);
            gamePlayUIController.gameObject.SetActive(false);
        }

        private void OnGameStart()
        {
            mainMenuUIController.gameObject.SetActive(false);
            gamePlayUIController.gameObject.SetActive(true);
        }
        private void OnDisable()
        {
            eventService.OnGameStart.RemoveListener(OnGameStart);
        }
    }
}