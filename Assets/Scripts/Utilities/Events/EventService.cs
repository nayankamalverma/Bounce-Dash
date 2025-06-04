namespace BounceDash.Scripts.Utilities
{
    public class EventService
    {
        public EventController OnGameStart;
        public EventController<int,int> OnGameOver;
        public EventController OnMainMenuButtonClicked;
        public EventController OnCoinCollected;
        public EventService()
        {
            OnGameStart = new EventController();
            OnGameOver = new EventController<int,int>();
            OnMainMenuButtonClicked = new EventController();
            OnCoinCollected = new EventController();
        }
    }
}