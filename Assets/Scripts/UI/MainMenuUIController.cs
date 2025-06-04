using UnityEngine;
using UnityEngine.UI;
using BounceDash.Scripts.Utilities;

namespace  BounceDash.Scripts.UI
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button inventoryButton;

        private EventService eventService;

        private void Awake()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
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
