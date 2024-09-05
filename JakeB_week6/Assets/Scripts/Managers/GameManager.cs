using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    //defaults to false
    public bool isGameOver;
    public GameObject gameOverCanvas;
    public GameObject uiCanvas;
    public ScoreManager scoreManager;

    public int lives = 3;
    private int currentLives;
    public Image healthImage;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        Cursor.visible = false;
        currentLives = lives;
        UpdateHealthUI();
        Time.timeScale = 1;
    }

    void Update() {

    }

    public void LoseLife() {
        currentLives--;
        UpdateHealthUI();

        if (currentLives <= 0) {
            GameOver();
        }
    }
    private void UpdateHealthUI() {
        // Update the fill amount of the health bar
        healthImage.fillAmount = (float)currentLives / lives / 3.3f;
    }

    //GameOver
    private void GameOver() {
        isGameOver = true;
        gameOverCanvas.SetActive(true);
        uiCanvas.SetActive(false);
        Cursor.visible = true;
        Time.timeScale = 0;
        scoreManager.SetGameOverScore();
    }
}