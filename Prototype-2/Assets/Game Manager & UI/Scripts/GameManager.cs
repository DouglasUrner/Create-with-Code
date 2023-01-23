using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
  // Game states. Set by UI and PlayerController.
  public bool gameIdle = true;      // Waiting to start.
  public bool gameEnding = false;   // Player has "lost," cleaning up.

  private int score = 0;
  private int health = 3;

  // UI interface
  public GameObject uiPrefab;
  private UIManager uiManager;

  private float savedTimeScale;

  // Public interface.
  public void AddPoints(int points) { score += points; }
  public void IncreaseHealth(int amt) { health += amt; }
  public void DecreaseHealth(int amt)
  {
    health -= amt;
    if (health <= 0)
    {
      EndGame();
    }
  }
  // Start is called before the first frame.
  void Start()
  {
    savedTimeScale = Time.timeScale;
    Time.timeScale = 0;

    // Instantiate the UI prefab if it is not found.
    if ((uiManager = GameObject.Find("UI").GetComponent<UIManager>()) == null)
    {
      var ui = Instantiate(uiPrefab);
      ui.name = "UI";
      uiManager = ui.GetComponent<UIManager>();
    }
    // Make sure we have an event system.
    if (FindObjectOfType<EventSystem>() == null)
    {
      var eventSystem = new GameObject("EventSystem",
        typeof(EventSystem),
        typeof(StandaloneInputModule)
      );
      DontDestroyOnLoad(eventSystem);
    }
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
    uiManager.UpdateScore(score);
    uiManager.UpdateHealth(health);
  }

  void EndGame()
  {
    Time.timeScale = 0;
    gameEnding = false;
    gameIdle = true;
    // Reload scene.
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    uiManager.DisplayGameOverMessage();
    score = 0;
    health = 3;
  }
}
