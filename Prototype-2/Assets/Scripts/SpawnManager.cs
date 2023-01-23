using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] animalPrefabs;

  // Defaults, tune in Inspector.
  public float spawnDelay = 2.0f;
  public float spawnInterval = 2.0f;
  public float spawnPosZ = 25.0f;

  private PlayerController playerController;
  private float xRange;

  // Start is called before the first frame update
  void Start()
  {
    playerController = GameObject.Find("Player").
      GetComponent<PlayerController>();
    xRange = playerController.xRange;
    InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnInterval);
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  void SpawnRandomAnimal()
  {
    Debug.Log("SpawnManager.SpawnRandomAnimal()");
    var animal = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
    Debug.Log($"Animal is: {animal.gameObject.name}");
    var spawnPos = new Vector3(Random.Range(-xRange, xRange), 0, spawnPosZ);
    Debug.Log(spawnPos);
    var go = Instantiate(animal, spawnPos, animal.transform.rotation);
    if (go == null)
    {
      Debug.Log($"Instantiate() returned null");
    }
  }
}
