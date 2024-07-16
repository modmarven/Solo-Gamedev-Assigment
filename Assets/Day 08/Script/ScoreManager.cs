using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    
    void Awake()
    {
       
    }

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void AddScore(int point)
    {
        score += point;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "kill: " + score;
    }

}
