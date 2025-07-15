using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnInterval = 2f;
    //public float spawnX = 0f;
    public float spawnY = 0.5f;
    public float spawnZStart = 10f;
    public float spawnZStep = 5f;

    private float nextSpawnZ;

    private void Start()
    {
        nextSpawnZ = spawnZStart;
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    private void SpawnObstacle()
    {
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning("No obstacle prefabs assigned!");
            return;
        }
        
        
        int index = Random.Range(0, obstaclePrefabs.Length);
        int spawnPosition = Random.Range(-5, 5);
        Vector3 spawnPos = new Vector3(spawnPosition, spawnY, nextSpawnZ);

        GameObject obstacle = Instantiate(
            obstaclePrefabs[index],
            spawnPos,
            Quaternion.identity
        );


        nextSpawnZ += spawnZStep;
    }
}
