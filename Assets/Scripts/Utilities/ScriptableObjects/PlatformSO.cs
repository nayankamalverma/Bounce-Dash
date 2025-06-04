using UnityEngine;
using BounceDash.Scripts.Level;

namespace BounceDash.Scripts.Utilities
{

    [CreateAssetMenu(fileName = "PlatformSO", menuName = "Scriptable Objects/PlatformSO")]
    public class PlatformSO : ScriptableObject
    {
        public PlatformType platformType;
        public GameObject platfromPrefab;
    }
}