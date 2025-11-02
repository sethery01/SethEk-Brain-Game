using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI cratesText;
    public TextMeshProUGUI levelText;

    [Header("Game Settings")]
    public int score = 0;
    public int ammo1 = 50;
    public int ammo2 = 50;
    public int ammo3 = 50;
    public float levelTime = 180f;
    public int cratesLeft = 5;

    [Header("Levels Settings")]
    public int currentLevel = 1;
    public float crateFallSpeed = 1f;
    public bool levelActive = true;
    public float crateSpawnInterval = 3f;

    private float timeRemaining;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // timeRemaining = levelTime;
        InitLevel(1);
    }

    void Update()
    {
        if (!levelActive) return;

        // Count down the timer
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            EndGame();
        }
        UpdateUI();
    }

    public void InitLevel(int level)
    {
        currentLevel = level;

        switch (level)
        {
            case 1:
                crateSpawnInterval = 3f;
                crateFallSpeed = 1f;
                cratesLeft = 5;
                levelTime = 90f;
                break;
            case 2:
                // ammo1 = ammo2 = ammo3 = 30;
                crateFallSpeed = 1.5f;
                crateSpawnInterval = 2f;
                cratesLeft = 10;
                levelTime = 60f;
                break;
            case 3:
                // ammo1 = ammo2 = ammo3 = 20;
                crateFallSpeed = 2f;
                crateSpawnInterval = 1.5f;
                cratesLeft = 15;
                levelTime = 40f;
                break;
            default:
                break;
        }
        timeRemaining = levelTime;
        levelActive = true;
        UpdateUI();
    }

    public void CrateDestroyed()
    {
        cratesLeft--;
        if (cratesLeft <= 0)
        {
            EndLevel(true);
        }
    }

    void EndLevel(bool success)
    {
        levelActive = false;
        if (success)
        {
            Debug.Log("Level complete: " + currentLevel);
            if (currentLevel < 3)
            {
                Invoke(nameof(NextLevel), 2f); // I had to add this to help with delay
            }
            else
            {
                Debug.Log("All levels complete! Final Score: " + score);
            }
        }
        else
        {
            Debug.Log("Level failed: " + currentLevel);
            Invoke(nameof(PrevLevel), 2f);
        }
    }

    void NextLevel()
    {
        InitLevel(currentLevel + 1);
    }

    void PrevLevel()
    {
        InitLevel(Mathf.Max(1, currentLevel - 1));
    }

    public void AddScore(int value)
    {
        score += value;
        if (score < 0) score = 0;
        UpdateUI();
    }

    public void FireShot(int bulletValue)
    {
        switch (bulletValue)
        {
            case 1:
                if (ammo1 > 0)
                {
                    ammo1--;
                }
                break;
            case 2:
                if (ammo2 > 0)
                {
                    ammo2--;
                }
                break;
            case 3:
                if (ammo3 > 0)
                {
                    ammo3--;
                }
                break;
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        ammoText.text = $"Ammo: {ammo1} | {ammo2} | {ammo3}";
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
        cratesText.text = "Crates Left: " + cratesLeft;
        if (levelText != null)
            levelText.text = "Level: " + currentLevel;
    }

    void EndGame()
    {
        Debug.Log("Game Over! Final Score: " + score);
    }
}
