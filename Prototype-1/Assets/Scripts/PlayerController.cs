using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30.0f;
    public float yawRate = 45.0f;
    public float yLimit = -15.0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (gameManager.gameIdle) { return; }

        var forwardInput = Input.GetAxis("Vertical");
        var steeringInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
        transform.Rotate(Vector3.up, steeringInput * yawRate * Time.deltaTime);

        // if (transform.position.y < yLimit) { gameManager.gameEnding = true; }
    }
}
