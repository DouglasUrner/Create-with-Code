using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
  public TextAsset gameInfoJSON;
  
  public GameObject leftUIPanel;
  public TextMeshProUGUI titleText;
  public TextMeshProUGUI descText;
  public Button startButton;

  private TextMeshProUGUI startButtonText;

  private GameManager gameManager;
  private GameInfo gameInfo = new GameInfo();

  void Start()
  {
    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    startButtonText = startButton.GetComponentInChildren<TextMeshProUGUI>();
    ResetUI();
  }

  void Update()
  {

  }

  public void ResetUI()
  {
    leftUIPanel.gameObject.SetActive(true);
    titleText.text = gameInfo.title;
    descText.text = gameInfo.description;
  }

  public void StartButtonClicked()
  {
    leftUIPanel.gameObject.SetActive(false);
    gameManager.gameIdle = false;
  }
}
