using System.Collections.Generic;
using BounceDash.Scripts.Utilities;
using UnityEngine;

namespace BounceDash.Scripts.Level
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private List<PlatformSO> platformSOList;
        [SerializeField] private int initialPlatformCount = 6;
        [SerializeField] private Transform platformSpawnPos;
        [SerializeField] private Transform platformDestroyPos;

        private PlatformObjectPool platformObjectPool;
        private LevelController levelController;
        private Vector2 initialSpawnPosition;
        private bool isPaused;

        private void Awake()
        {
            platformObjectPool = new PlatformObjectPool();
            platformObjectPool.SetService(transform , platformSOList);
            initialSpawnPosition = platformSpawnPos.position;
            SpawnInitialPlatforms();
            isPaused = true;
        }
        public void SetReferences(LevelController levelController)
        {
            this.levelController = levelController;
        }

        public void OnGameStart()
        {
            platformObjectPool.ReturnAllItem();
            SpawnInitialPlatforms();
        }

        private void Update()
        {
            if (!isPaused)
            {
                MoveBuildings();
            }
        }
        private void MoveBuildings()
        {
            foreach (var pooledItem in platformObjectPool.pooledItems)
            {
                var platform = pooledItem.Item;
                if (pooledItem.isUsed)
                {
                    Vector3 targetPosition = platform.transform.position + (Vector3.down * levelController.GetMoveSpeed() * Time.deltaTime);
                    platform.transform.position = Vector3.Lerp(platform.transform.position, targetPosition, 0.5f);

                    if (platform.transform.position.y <= platformDestroyPos.position.y)
                    {
                        platformObjectPool.ReturnItem(pooledItem);
                        ConfigureBuilding(platformObjectPool.GetItem(GetRandomBuilding()), platformSpawnPos);
                    }
                }
            }
        }
        private void SpawnInitialPlatforms()
        {
            platformSpawnPos.position = initialSpawnPosition;
            for (int i = 0; i < initialPlatformCount; i++)
            {
                if(i!=0)platformSpawnPos.position = new Vector3(platformSpawnPos.position.x , platformSpawnPos.position.y + 2f , platformSpawnPos.position.z);

                if(i==0 || i==2) ConfigureBuilding(platformObjectPool.GetItem(PlatformType.TYPE101), platformSpawnPos);
                else if(i==1) ConfigureBuilding(platformObjectPool.GetItem(PlatformType.TYPE010), platformSpawnPos);
                else ConfigureBuilding(platformObjectPool.GetItem(GetRandomBuilding()), platformSpawnPos);
            }
        }
        private PlatformType GetRandomBuilding()
        {
            return platformSOList[Random.Range(0, platformSOList.Count)].platformType;
        }
        private void ConfigureBuilding(GameObject item, Transform spawnPos)
        {
            item.transform.position = spawnPos.position;
            item.transform.rotation = spawnPos.rotation;
        }

        public void SetPaused(bool isPaused) => this.isPaused = isPaused;
    }
}