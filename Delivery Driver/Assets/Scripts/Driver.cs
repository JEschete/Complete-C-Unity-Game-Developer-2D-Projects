using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f; // Speed at which the object will rotate
    [SerializeField] float moveSpeed = 60.0f; // Speed at which the object will move
    [SerializeField] float slowSpeed = 0.15f;
    [SerializeField] float fastSpeed = 120.0f;
    [SerializeField] float defaultMoveSpeed = 0.2f;

    // Called before the first frame update
    void Start()
    {
        // Initialization code can be placed here if needed
    }

    // Called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Rotate the object around the z-axis
        transform.Rotate(0, 0, -steerAmount);

        // Move the object up
        transform.Translate(0, moveAmount, 0);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = fastSpeed; // Update moveSpeed to fastSpeed when boost is triggered
            Debug.Log("Boost!");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Slow")
        {
            moveSpeed = slowSpeed; // Update moveSpeed to 0 when obstacle is triggered
            Debug.Log("Slow!");
            StartCoroutine(ResetSpeedAfterDelay()); // Start the coroutine
        }
    }

    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        moveSpeed = defaultMoveSpeed; // Reset moveSpeed to defaultMoveSpeed
    }
}