using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // Default speed, tune in Inspector.
  public float speed = 5.0f;
  public float outOfFrameY = -20.0f;

  private Rigidbody playerRb;
  private GameObject focalPoint;

  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    focalPoint = GameObject.Find("Focal Point");

    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
    var forwardInput = Input.GetAxis("Vertical");
    playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

    // Detect if we've fallen off of the island.
    if (transform.position.y < outOfFrameY)
    {
      gameManager.gameOver = true;
    }
  }
}
