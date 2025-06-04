using UnityEngine;

namespace BounceDash.Scripts.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private float platformMoveSpeed;

        [SerializeField] private PlatformController platformController;

        private void Start()
        {
            platformController.SetReferences(this);
        }

        public float GetMoveSpeed() => platformMoveSpeed;
    }
}