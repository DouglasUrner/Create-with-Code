using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public GameObject powerupIndicator;

  // Defaults, tune in Inspector.
  public float speed = 5.0f;
  public bool havePowerup = false;
  public float powerupStrength = 15.0f;
  public float powerupTTL = 7.0f;
  public Vector3 powerupIndicatorOffset;
  public float outOfFrameY = -20.0f;

  private Rigidbody playerRb;
  private GameObject focalPoint;

  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    focalPoint = GameObject.Find("Focal Point");
    powerupIndicatorOffset = transform.position -
      powerupIndicator.transform.position;

    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
    if (gameManager.gameIdle == false)
    {
      var forwardInput = Input.GetAxis("Vertical");
      playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
      // Move the powerup indicator to track our position.
      powerupIndicator.transform.position =
        transform.position + powerupIndicatorOffset;
    }

    // Detect if we've fallen off of the island.
    if (transform.position.y < outOfFrameY)
    {
      gameManager.gameEnding = true;
    }
  }

  // Collect Powerup.
  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Powerup"))
    {
      havePowerup = true;
      powerupIndicator.gameObject.SetActive(true);
      Destroy(other.gameObject);
      StartCoroutine(PowerupCountdownRoutine());
    }
  }

  IEnumerator PowerupCountdownRoutine()
  {
    yield return new WaitForSeconds(powerupTTL);
    havePowerup = false;
    powerupIndicator.gameObject.SetActive(false);
  }

  // Apply extra "kick" on collision if we have a powerup.
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Enemy") && havePowerup)
    {
      var enemyRb = collision.gameObject.GetComponent<Rigidbody>();
      var awayFromPlayer = collision.gameObject.transform.position -
        transform.position;
      
      enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
    }
  }
}
