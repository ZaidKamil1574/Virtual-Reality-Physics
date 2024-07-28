using UnityEngine;
using TMPro;

public class ForceDisplay : MonoBehaviour
{
    public TMP_Text forceText; // Reference to the TextMeshPro Text element
    private Rigidbody rb;
    private Vector3 previousVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (forceText == null)
        {
            Debug.LogError("ForceDisplay: No TextMeshPro Text component assigned.");
        }

        previousVelocity = rb.velocity;
    }

    void Update()
    {
        if (rb != null && forceText != null)
        {
            // Calculate the force based on the change in velocity
            Vector3 currentVelocity = rb.velocity;
            Vector3 force = rb.mass * (currentVelocity - previousVelocity) / Time.deltaTime;
            float forceMagnitude = force.magnitude;

            // Update the UI text with the force magnitude
            forceText.text = "Force: " + forceMagnitude.ToString("F2") + " N";

            // Update the previous velocity for the next frame
            previousVelocity = currentVelocity;
        }
    }
}

