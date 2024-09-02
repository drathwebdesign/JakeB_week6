using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    Rigidbody rb;
    public Vector2 randomForce, randomTorque;
    public float xRange;

    void Start() {
        rb = GetComponent<Rigidbody>();
        HandleMovement();
        HandleRotation();
        HandleSpawn();
    }

    void Update() {
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
        transform.position = new Vector3(Random.Range(-xRange, xRange), transform.position.y, transform.position.z);
    }
}