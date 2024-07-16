using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float duration = 60f;
    public TextMeshProUGUI timerText;

    private float remainingTime;
    private bool isRunning = false;

    public delegate void TimerEnded();
    public static event TimerEnded OnTimerEnded;

    void Start()
    {
        startTimer();
    }

    private void startTimer()
    {
        remainingTime = duration;
        isRunning = true;
        UpdateTimerText();
    }

    void Update()
    {
        if (isRunning)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();

            if (remainingTime <= 0)
            {
                remainingTime = 0f;
                isRunning = false;
                if (OnTimerEnded != null)
                {
                    OnTimerEnded();
                }
            }
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Timer : " + Mathf.CeilToInt(remainingTime).ToString();
        }
    }
}
