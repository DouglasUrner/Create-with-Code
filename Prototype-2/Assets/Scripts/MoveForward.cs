using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
  // Defaults, tune in the Inspector.
  public float speed = 10.0f;
  public float lowerBound = -5.0f;
  public float upperBound = 20.0f;

  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector3.forward * speed * Time.deltaTime);

    if (transform.position.z > upperBound)
    {
      Destroy(gameObject);
    }
    else if (transform.position.z < lowerBound)
    {
      gameManager.DecreaseHealth(1);
      Destroy(gameObject);
    }
  }
}
