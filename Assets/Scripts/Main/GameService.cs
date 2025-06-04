using BounceDash.Scripts.Level;
using BounceDash.Scripts.Player;
using BounceDash.Scripts.UI;
using BounceDash.Scripts.Utilities;
using UnityEngine;

namespace BounceDash.Scripts.Main
{
    public class GameService : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerController playerController;

        #region services
        [Header("Services")]
        [SerializeField] private UIService UIService;

        private EventService EventService;
        private LevelService LevelService;
        private PlayerService PlayerService;
        #endregion
        private void Awake()
        {
            EventService = new EventService();
            LevelService = new LevelService();
            PlayerService = new PlayerService();
            SetServiceAndReferences();
        }

        private void SetServiceAndReferences()
        {
            UIService.SetServices(EventService);
            LevelService.SetServices(EventService);
            PlayerService.SetServices(EventService,playerController);
        }
        private void OnDestroy()
        {
            LevelService.OnDestroy();
            PlayerService.OnDestroy();
        }
    }
}
