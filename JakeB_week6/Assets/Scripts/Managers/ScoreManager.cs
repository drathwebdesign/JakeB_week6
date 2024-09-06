using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    int score = 0;

    void Start()
    {
        UpdateScoreUI();
    }


    void Update()
    {
        
    }
    public void GainScore(int amount = 1) {
        score += amount;
        UpdateScoreUI();
    }
    private void UpdateScoreUI() {
        scoreText.text = "Splatted: " + score.ToString();
    }
    public void SetGameOverScore() {
        if (gameOverScoreText != null) {
            gameOverScoreText.text = "Total Splatted: " + score.ToString();
        }
    }
}