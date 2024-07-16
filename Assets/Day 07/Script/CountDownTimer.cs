using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CountDownTimer : MonoBehaviour
{
    public float timeRemaining = 10f;
    public bool timeRunning = false;
    public TextMeshProUGUI timeText;
    
    // Start is called before the first frame update
    void Start()
    {
        timeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timeRunning = false;
            }
        }
    }

    private void DisplayTime(float timerToDisplay)
    {
        timerToDisplay += 1;

        float minutes = Mathf.FloorToInt(timerToDisplay / 60);
        float seconds = Mathf.FloorToInt(timerToDisplay % 60);

        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
