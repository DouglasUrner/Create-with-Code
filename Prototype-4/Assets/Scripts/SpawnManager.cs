using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject enemyPrefab;
  public GameObject powerupPrefab;
  public float spawnRange = 9;
  public int waveNumber = 1;
  public int enemyCount;

  // Start is called before the first frame update
  void Start()
  {
       
  }

  // Update is called once per frame
  void Update()
  {
    enemyCount = FindObjectsOfType<Enemy>().Length;
    if (enemyCount == 0)
    {
      Instantiate(powerupPrefab,
        GenerateSpawnPosition(), powerupPrefab.transform.rotation);
      SpawnEnemyWave(waveNumber);
    }
  }

  void SpawnEnemyWave(int enemiesToSpawn)
  {
    for (int i = 0; i < enemiesToSpawn; i++)
    {
      Instantiate(enemyPrefab,
        GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
  }

  private Vector3 GenerateSpawnPosition()
  {
    var spawnPosX = Random.Range(-spawnRange, spawnRange);
    var spawnPosZ = Random.Range(-spawnRange, spawnRange);
    return new Vector3(spawnPosX, 0, spawnPosZ);
  }
}
