namespace BounceDash.Scripts.Utilities
{
    public class EventService
    {
        public EventController OnGameStart;
        public EventController<int,int> OnGameOver;
        public EventController OnCoinCollected;
        public EventService()
        {
            OnGameStart = new EventController();
            OnGameOver = new EventController<int,int>();
            OnCoinCollected = new EventController();
        }
    }
}