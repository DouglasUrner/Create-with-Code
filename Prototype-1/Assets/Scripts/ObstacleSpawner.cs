using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstacleCount = 10;
    public float spacingMin = 20.0f;
    public float spacingMax = 30.0f;
    public float xRange = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacles();
    }

    void SpawnObstacles()
    {
        var lastZ = transform.position.z;

        for (int i = 0; i < obstacleCount; i++)
        {
            var pos = RandomSpawnPosition(lastZ);
            Instantiate(obstaclePrefab, pos, obstaclePrefab.transform.rotation, transform);
            lastZ = pos.z;
        }
    }

    Vector3 RandomSpawnPosition(float lastZ)
    {
        return new Vector3(
            Random.Range(-xRange, xRange),
            0,
            lastZ + Random.Range(spacingMin, spacingMax)
        );
    }
}
