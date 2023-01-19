using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
  // Game states. Set by UI and PlayerController.
  public bool gameIdle = true;      // Waiting to start.
  public bool gameEnding = false;   // Player has "lost," cleaning up.

  private float savedTimeScale;

  // Start is called before the first frame.
  void Start()
  {
    //DontDestroyOnLoad(gameObject);
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
    gameIdle = true;
    // Reload scene.
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
