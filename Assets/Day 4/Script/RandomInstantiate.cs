using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomInstantiate : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Canvas canvas;
    public int maxButton;
    public TextMeshProUGUI scoreText;
    private int score;

    public float spawnInterval;
    public float buttonLifeTime;
    private bool canSpawnButton = true;

    [Space]
    [Header("Color List")]
    public Color[] buttonColor;

    [Space]
    [Header("Boundary Value")]
    public float minX = -100f;
    public float maxX = 100f;
    public float minY = -100f;
    public float maxY = 100f;

    private void OnEnable()
    {
        Timer.OnTimerEnded += StopSpawningButton;
    }

    private void OnDisable()
    {
        Timer.OnTimerEnded -= StopSpawningButton;
    }

    private void Start()
    {
        StartCoroutine(InstantiateAndDestroyButton());
    }

    private IEnumerator InstantiateAndDestroyButton()
    {
        while (true)
        {
            if (canSpawnButton && Random.value > 0f && canvas.transform.childCount < maxButton)
            {
                InstantiateButton();
            }
            
            yield return new WaitForSeconds(spawnInterval);
        }     
    }

    private void InstantiateButton()
    {
        GameObject newButton = Instantiate(buttonPrefab);
        newButton.transform.SetParent(canvas.transform, false);

        RectTransform rectTransform = newButton.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Image buttonImage = newButton.GetComponent<Image>();
        if (buttonColor.Length > 0)
        {
            buttonImage.color = buttonColor[Random.Range(0, buttonColor.Length)];
        }

        Button buttonComponent = newButton.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => DestroyButton(newButton));

        StartCoroutine(DestroyButtonAfterLifeTime(newButton, buttonLifeTime));
    }

    private void DestroyButton(GameObject button)
    {
        Destroy(button);
        score += 10;
        scoreText.text = "Score : " + score.ToString();
        
    }

    private IEnumerator DestroyButtonAfterLifeTime(GameObject button, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(button);
    }

    private void StopSpawningButton()
    {
        canSpawnButton = false;
    }
}
