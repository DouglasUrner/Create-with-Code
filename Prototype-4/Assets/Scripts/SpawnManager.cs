using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject enemyPrefab;
  public float spawnRange = 9;

  // Start is called before the first frame update
  void Start()
  {
    Instantiate(enemyPrefab,
      GenerateSpawnPosition(), enemyPrefab.transform.rotation);
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  private Vector3 GenerateSpawnPosition()
  {
    var spawnPosX = Random.Range(-spawnRange, spawnRange);
    var spawnPosZ = Random.Range(-spawnRange, spawnRange);
    return new Vector3(spawnPosX, 0, spawnPosZ);
  }
}
