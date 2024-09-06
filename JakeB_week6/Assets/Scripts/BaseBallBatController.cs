using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBallBatController : MonoBehaviour
{
    public float rotationSpeed = 40f;  // Speed of rotation after swing
    public float hitForce = 50f;
    private Quaternion currentRotation;

    public ParticleSystem hitParticleEffect;
    [SerializeField] AudioClip hitSoundClip;

    private bool isSwinging = false;
    private bool isFlipped = false;

    void Start() {
        currentRotation = transform.rotation;
    }

    void Update() {
        if (!GameManager.instance.isGameOver) {
            FollowMouse();
        }
        if (Input.GetMouseButtonDown(1)) {
            ToggleBatFlip();
        }
        // Handle click for swinging the bat
        if (Input.GetMouseButtonDown(0) && !isSwinging) {
            StartCoroutine(SwingBat());
        }
    }

    void FollowMouse() {
        // Convert mouse position to world position and move the bat
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // Distance to camera

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }

    void ToggleBatFlip() {
        // Flip the bat by 180 degrees on the Y-axis
        isFlipped = !isFlipped;
        currentRotation = isFlipped
            ? Quaternion.Euler(0, 180, 0)
            : Quaternion.Euler(0, 0, 0);

        transform.rotation = currentRotation;
    }

    IEnumerator SwingBat() {
        isSwinging = true;

        // Determine the target rotation based on whether the bat is flipped
        float swingAngle = isFlipped ? 90f : 90f;
        Quaternion targetRotation = Quaternion.Euler(0, swingAngle, 0);

        // Rotate to the target rotation
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f) {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }

        // Rotate back to the original orientation (0 or 180 degrees)
        Quaternion finalRotation = isFlipped ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        while (Quaternion.Angle(transform.rotation, finalRotation) > 0.1f) {
            transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, Time.deltaTime * rotationSpeed);
            yield return null;
        }

        transform.rotation = finalRotation;  // Ensure it's exactly set
        isSwinging = false;
    }

    void OnCollisionEnter(Collision collision) {
        // Check if the bat hits a target with a Rigidbody
        Rigidbody targetRigidbody = collision.rigidbody;

        // Apply force in the direction the bat is facing
        //Vector3 forceDirection = isFlipped ? -transform.right : transform.right;
        Vector3 forceDirection = Vector3.forward;
            targetRigidbody.AddForce(forceDirection * hitForce, ForceMode.Impulse);
        //
        hitParticleEffect.Play();
        SoundFXManager.Instance.PlaySoundFXClip(hitSoundClip, transform, 1f);
    }
}