using BounceDash.Scripts.Utilities;

namespace BounceDash.Scripts.Level
{
    public class LevelService
    {
        private EventService eventService;

        public void SetServices(EventService eventService)
        {
            this.eventService = eventService;
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            eventService.OnGameStart.AddListener(OnGameStart);
        }

        private void OnGameStart()
        {
            
        }


        public void OnDestroy()
        {
            eventService.OnGameStart.RemoveListener(OnGameStart);
        }
    }
}