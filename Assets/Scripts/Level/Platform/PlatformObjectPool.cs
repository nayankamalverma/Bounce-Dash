using System.Collections.Generic;
using BounceDash.Scripts.Utilities;
using UnityEngine;

namespace BounceDash.Scripts.Level
{
    public class PlatformObjectPool : BaseGenericObjectPool<PlatformType>
    {
        private List<PlatformSO> platformSOList;
        private Transform parentTransform;
        public void SetService(Transform parentTransform, List<PlatformSO> platformSOList)
        {
            this.parentTransform = parentTransform;
            this.platformSOList = platformSOList;
        }
        protected override GameObject CreateItem(PlatformType type)
        {
            return GameObject.Instantiate(GetPrefab(type), parentTransform);
        }
        private GameObject GetPrefab(PlatformType type)
        {
            return platformSOList.Find(i => i.platformType == type).platfromPrefab;
        }
    }

    public enum PlatformType
    {
        TYPE100,
        TYPE101,
        TYPE101c,
        TYPE001,
        TYPE010,
    }
}