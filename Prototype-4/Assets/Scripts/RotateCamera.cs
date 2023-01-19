using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
  // Degrees/sec -- default, tune in Inspector.
  public float rotationSpeed = 90;

  private GameManager gameManager;

  // Start is called before the first frame update
  void Awake()
  {
    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
    if (gameManager.gameIdle == false)
    {
      var rotationInput = Input.GetAxis("Horizontal");
      // Rotate CW on right arrow with Vector3.down.
      transform.Rotate(Vector3.down,
        rotationInput * rotationSpeed * Time.deltaTime);
    }
  }
}
