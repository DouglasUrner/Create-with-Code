using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
  public TextAsset gameInfoJSON;
  
  public GameObject leftUIPanel;
  public TextMeshProUGUI titleText;
  public TextMeshProUGUI descText;
  public Button startButton;

  private GameObject scorePanel;
  private TextMeshProUGUI scoreText;
  private GameObject healthPanel;
  private TextMeshProUGUI healthText;

  private TextMeshProUGUI startButtonText;

  private GameManager gameManager;
  private GameInfo gameInfo = new GameInfo();

  void Start()
  {
    Debug.Log("UIManager.Start()");

    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    startButtonText = startButton.GetComponentInChildren<TextMeshProUGUI>();

    gameInfo = JsonUtility.FromJson<GameInfo>(gameInfoJSON.text);

    scorePanel = GameObject.Find("Score Panel");
    scoreText = scorePanel.GetComponentInChildren<TextMeshProUGUI>();

    healthPanel = GameObject.Find("Health Panel");
    healthText = healthPanel.GetComponentInChildren<TextMeshProUGUI>();

    PositionUIElements();
    ResetUI();
  }

  void Update()
  {

  }

  public void UpdateScore(int value)
  {
    scoreText.text = $"{gameInfo.scoreLabel}: {value}";
  }

  public void UpdateHealth(int value)
  {
    healthText.text = $"{gameInfo.healthLabel}: {value}";
  }

  public void ResetUI()
  {
    leftUIPanel.gameObject.SetActive(true);
    scorePanel.SetActive(false);
    healthPanel.SetActive(false);
    titleText.text = gameInfo.title;
    descText.text = gameInfo.description;
    startButtonText.text = gameInfo.startButtonLabel;
  }

  public void StartButtonClicked()
  {
    Debug.Log("StartButtonClicked()");

    leftUIPanel.gameObject.SetActive(false);
    if (gameInfo.displayScore) { scorePanel.SetActive(true); }
    if (gameInfo.displayHealth) { healthPanel.SetActive(true); }
    gameManager.gameIdle = false;
  }

  public void DisplayGameOverMessage()
  {
    gameInfo.description = gameInfo.gameOverMessage;
    ResetUI();
  }

  void PositionUIElements()
  {

  }
}
