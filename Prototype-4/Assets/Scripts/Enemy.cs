using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float speed;

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
  }
}
