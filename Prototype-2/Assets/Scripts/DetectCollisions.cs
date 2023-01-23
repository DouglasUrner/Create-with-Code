using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
  // GameManager tracks the score.
  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  void OnTriggerEnter(Collider other)
  {
    Destroy(other.gameObject);
    Destroy(gameObject);
    gameManager.AddPoints(1);
  }
}
