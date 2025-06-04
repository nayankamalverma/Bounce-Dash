namespace BounceDash.Scripts.Utilities
{
    public class EventService
    {
        public EventController OnGameStart;
        public EventController OnGameOver;
        public EventService()
        {
            OnGameStart = new EventController();
            OnGameOver = new EventController();
        }
    }
}