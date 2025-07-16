using UnityEngine;
using Zenject;

namespace RunnerGame.Spawning
{
    public sealed class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _obstaclePrefabs;

        [SerializeField]
        private float _spawnInterval = 2f;

        [SerializeField]
        private float _spawnY = 0.5f;

        [SerializeField]
        private float _spawnZStart = 10f;

        [SerializeField]
        private float _spawnZStep = 5f;

        private float _nextSpawnZ;

        private void Start()
        {
            _nextSpawnZ = _spawnZStart;
            InvokeRepeating(nameof(SpawnObstacle), 0f, _spawnInterval);
        }

        private void SpawnObstacle()
        {
            if (_obstaclePrefabs == null || _obstaclePrefabs.Length == 0)
            {
                return;
            }

            int prefabIndex = Random.Range(0, _obstaclePrefabs.Length);
            int spawnX = Random.Range(-5, 5);

            Vector3 spawnPosition = new Vector3(spawnX, _spawnY, _nextSpawnZ);

            GameObject spawnedObstacle = Instantiate(
                _obstaclePrefabs[prefabIndex],
                spawnPosition,
                Quaternion.identity
            );

            _nextSpawnZ += _spawnZStep;
        }
    }
}