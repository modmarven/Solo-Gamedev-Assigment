using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Button restartButton;
    public Button exitButton;
    private ScoreManager scoreManager;

    void Awake()
    {
    
    }

    private void Start()
    {
        gameOverUI.SetActive(false);

        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Day 08");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
       
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
