using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDropper : MonoBehaviour
{
    public GameObject cargoPrefab;

    public float speed = 25;
    public float delay = 2.0f;
    public float spawnInterval = 1.5f;

    private PlayerController vehiclePC;
    private Vector3 offset;
    private GameObject initialCargoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        initialCargoPrefab = GameObject.Find("Cargo");
        offset = transform.position - initialCargoPrefab.transform.position;
        InvokeRepeating("SpawnCargo", delay, spawnInterval);
        //vehiclePC = GameObject.Find("Vehicle").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void SpawnCargo()
    {
        Instantiate(cargoPrefab, transform.position - offset, cargoPrefab.transform.rotation);
    }
}
