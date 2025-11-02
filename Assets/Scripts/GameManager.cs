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

    [Header("Game Settings")]
    public int score = 0;
    public int ammo1 = 50;
    public int ammo2 = 50;
    public int ammo3 = 50;
    public float levelTime = 180f;
    public int cratesLeft = 5;

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
        timeRemaining = levelTime;
    }

    void Update()
    {
        // Count down the timer
        timeRemaining -= Time.deltaTime;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            EndGame();
        }
        UpdateUI();
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
    }
    
    void EndGame()
    {
        Debug.Log("Game Over! Final Score: " + score);
    }
}
