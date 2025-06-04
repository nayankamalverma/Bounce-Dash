using BounceDash.Scripts.Utilities;

namespace BounceDash.Scripts.Level
{
    public class LevelService
    {
        private LevelController levelController;
        private EventService eventService;

        public void SetServices(EventService eventService, LevelController levelController)
        {
            this.eventService = eventService;
            this.levelController = levelController;
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            eventService.OnGameStart.AddListener(OnGameStart);
            eventService.OnGameOver.AddListener(OnGameOver);
        }

        private void OnGameStart()
        {
            levelController.OnGameStart();
        }

        private void OnGameOver(int score,int coin)
        {
            levelController.OnGameOver();
        }

        public void OnDestroy()
        {
            eventService.OnGameStart.RemoveListener(OnGameStart);
            eventService.OnGameOver.RemoveListener(OnGameOver);
        }
    }
}