using System.Collections.Generic;
using BounceDash.Scripts.Utilities;
using UnityEngine;

namespace BounceDash.Scripts.Level
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private List<PlatformSO> platformSOList;
        [SerializeField] private int initialBuildingCount = 8;
        [SerializeField] private Transform buildingSpawnPos;
        [SerializeField] private Transform buildingDestroyPos;

        private PlatformObjectPool platformObjectPool;
        private LevelController levelController;
        private bool isPaused;

        private void Awake()
        {
            platformObjectPool = new PlatformObjectPool();
            platformObjectPool.SetService(transform , platformSOList);
            SpawnInitialBuilding();
            isPaused = true;
        }
        public void SetReferences(LevelController levelController)
        {
            this.levelController = levelController;
        }

        private void Update()
        {
            if (!isPaused)
            {
                MoveBuildings();
            }
        }
        private void MoveBuildings()
        {//need to change locig object will move in y axis
            foreach (var pooledItem in platformObjectPool.pooledItems)
            {
                var building = pooledItem.Item;
                if (pooledItem.isUsed)
                {
                    Vector3 targetPosition = building.transform.position + (Vector3.left * levelController.GetMoveSpeed() * Time.deltaTime);
                    building.transform.position = Vector3.Lerp(building.transform.position, targetPosition, 0.5f);

                    if (building.transform.position.y <= buildingDestroyPos.position.y)
                    {
                        platformObjectPool.ReturnItem(pooledItem);
                        ConfigureBuilding(platformObjectPool.GetItem(GetRandomBuilding()), buildingSpawnPos);
                    }
                }
            }
        }
        private void SpawnInitialBuilding()
        {
            buildingSpawnPos.position = Vector3.zero;
            for (int i = 0; i < initialBuildingCount; i++)
            {
                if (i != 0) buildingSpawnPos.position = new Vector3(buildingSpawnPos.position.x + 10, buildingSpawnPos.position.y, buildingSpawnPos.position.z);
                ConfigureBuilding(platformObjectPool.GetItem(GetRandomBuilding()), buildingSpawnPos);
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

    }
}