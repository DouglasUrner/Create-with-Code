using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public GameObject foodPrefab;

  // Default values, tune in Inspector. Changes here will NOT
  // override values set in the Inspector.
  public float speed = 40.0f;
  public float xRange = 10.0f;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update()
  {
    // Character movement.
    var position = transform.position;
    var horizontalInput = Input.GetAxis("Horizontal");

    position.x += horizontalInput * speed * Time.deltaTime;

    // Make sure that we stay in bounds.
    if (position.x < -xRange)
    {
      position.x = -xRange;
    }
    else if (position.x > xRange)
    {
      position.x = xRange;
    }

    transform.position = position;

    // Fling food when spacebar is pressed.
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Instantiate(foodPrefab, position, foodPrefab.transform.rotation);
    }
  }
}
