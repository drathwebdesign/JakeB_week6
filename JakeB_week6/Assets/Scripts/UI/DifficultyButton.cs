using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour {

    void Start() {
    }

    void Update() {
    }

    public void ChangeDifficulty(float _yValue) {
        // Store the difficulty spawn rate in PlayerPrefs
        PlayerPrefs.SetFloat("spawnRateY", _yValue);

        ReloadScene(0.1f);
    }

    void ReloadScene(float delay) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }
}
// Set a playerPref over here & Get That value in Spawn Manager