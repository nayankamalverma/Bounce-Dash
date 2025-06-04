using BounceDash.Scripts.Utilities;

namespace BounceDash.Scripts.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private EventService eventService;
        public void SetServices(EventService eventService,PlayerController playerController)
        {
            this.eventService = eventService;
            this.playerController = playerController;
            playerController.SetServices(eventService);
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            eventService.OnGameStart.AddListener(playerController.OnGameStart);
            eventService.OnGameOver.AddListener(playerController.OnGameOver);
        }
        public void OnDestroy()
        {
            eventService.OnGameStart.RemoveListener(playerController.OnGameStart);
            eventService.OnGameOver.RemoveListener(playerController.OnGameOver);
        }
    }
}