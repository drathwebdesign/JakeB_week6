using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    Rigidbody rb;
    public Vector2 randomForce, randomTorque;
    public float xRange;

    private ScoreManager scoreManager;

    void Start() {
        rb = GetComponent<Rigidbody>();
        scoreManager = FindObjectOfType<ScoreManager>();
        HandleMovement();
        HandleRotation();
        HandleSpawn();
    }

    void Update() {
        DestroyOffScreen();
    }

    void HandleMovement() {
        rb.AddForce(Vector3.up * Random.Range(randomForce.x, randomForce.y), ForceMode.Impulse);
    }

    void HandleRotation() {
        rb.AddTorque(Random.Range(randomTorque.x, randomTorque.y),  // X-axis torque
             Random.Range(randomTorque.x, randomTorque.y),  // Y-axis torque
             Random.Range(randomTorque.x, randomTorque.y),  // Z-axis torque
             ForceMode.Impulse);
    }

    void HandleSpawn() {
        transform.position = new Vector3(Random.Range(-xRange, xRange), -6, 0);
    }

    void DestroyOffScreen() {
        if (transform.position.y < -10) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Backboard")) {
            if (transform.tag == "Zombie") {
                scoreManager.GainScore();
                Destroy(gameObject);
            } else if (transform.tag == "Woman" || transform.tag == "Police") {
                GameManager.instance.LoseLife();
                Destroy(gameObject);
            } else if (transform.tag == "Mystery") {
                // Mystery stuff
                Destroy(gameObject);
            }
        }
    }
}