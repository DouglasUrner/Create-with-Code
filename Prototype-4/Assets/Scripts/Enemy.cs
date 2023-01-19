using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float speed;
  public float outOfFrameY = -20.0f;

  private Rigidbody enemyRb;
  private GameObject player;
  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    enemyRb = GetComponent<Rigidbody>();
    player = GameObject.Find("Player");
    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
  }

  // Update is called once per frame
  void Update()
  {
    if (gameManager.gameIdle) { return; }

    var lookDirection = (player.transform.position - transform.position).
      normalized;

    enemyRb.AddForce(lookDirection * speed);

    if (transform.position.y < outOfFrameY)
    {
      Destroy(gameObject);
    }
  }
}
