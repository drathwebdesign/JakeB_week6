using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    GameManager gameManager;

    public Vector2 spawnRate = new Vector2(0.5f, 2f);

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        float savedYValue = PlayerPrefs.GetFloat("spawnRateY", 2f); // Default value
        spawnRate = new Vector2(0.5f, savedYValue);


        StartCoroutine(spawnTargets());
    }

    void Update()
    {
    }

    IEnumerator spawnTargets() {
        while (!gameManager.isGameOver) {
            yield return new WaitForSeconds(Random.Range(spawnRate.x, spawnRate.y));
            int randomSpawnIndex = Random.Range(0, targetPrefabs.Length);
            Instantiate(targetPrefabs[randomSpawnIndex]);
        }
    }
}