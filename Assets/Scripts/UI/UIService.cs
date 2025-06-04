using BounceDash.Scripts.Utilities;
using UnityEngine;

namespace BounceDash.Scripts.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private MainMenuUIController mainMenuUIController;

        private EventService eventService;

        public void SetServices(EventService eventService)
        {
            this.eventService = eventService;
            mainMenuUIController.SetService(eventService);
            AddEventListeners();
        }
        private void AddEventListeners()
        {
            eventService.OnGameStart.AddListener(OnGameStart);
        }

        private void OnGameStart()
        {
            mainMenuUIController.gameObject.SetActive(false);
        }
        private void OnDestroy()
        {
            eventService.OnGameStart.RemoveListener(OnGameStart);
        }
    }
}