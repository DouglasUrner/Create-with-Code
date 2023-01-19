using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  // Game states. Set by UI and PlayerController.
  public bool gameIdle = true;      // Waiting to start.
  public bool gameEnding = false;   // Player has "lost," cleaning up.

  private float savedTimeScale;

  // Awake is called when we become active in the game.
  void Awake()
  {
    DontDestroyOnLoad(gameObject);
    savedTimeScale = Time.timeScale;
  }

  // Update is called once per frame
  void Update()
  {
    if (!gameIdle)
    {
      StartGame();
    }

    if (gameEnding)
    {
      EndGame();
    }
  }

  void StartGame()
  {
    Time.timeScale = savedTimeScale;
  }

  void EndGame()
  {
    Time.timeScale = 0;
    gameEnding = false;
    // Reload scene.
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
