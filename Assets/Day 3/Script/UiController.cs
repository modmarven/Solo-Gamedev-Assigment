using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Day 3");
        Time.timeScale = 1;
    }
}
