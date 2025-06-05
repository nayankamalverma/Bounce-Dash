using UnityEngine;

namespace BounceDash.Scripts.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private float platformMoveSpeed;

        [SerializeField] private PlatformController platformController;
        private bool isPaused;

        private void Start()
        {
            platformController.SetReferences(this);
            isPaused = true;
        }

        public void OnGameStart()
        {
            isPaused = false;
            platformController.SetPaused(isPaused);
            platformController.OnGameStart();
        }

        public void OnGameOver()
        {
            isPaused = true;
            platformController.SetPaused(isPaused);
        }

        public float GetMoveSpeed() => platformMoveSpeed;
        
    }
}