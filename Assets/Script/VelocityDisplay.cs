using UnityEngine;
using TMPro;

public class VelocityDisplay : MonoBehaviour
{
    public TMP_Text velocityText; // Reference to the TextMeshPro Text element
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (velocityText == null)
        {
            Debug.LogError("VelocityDisplay: No TextMeshPro Text component assigned.");
        }
    }

    void Update()
    {
        if (rb != null && velocityText != null)
        {
            Vector3 velocity = rb.velocity;
            velocityText.text = "Velocity: " + velocity.magnitude.ToString("F2") + " m/s";
        }
    }
}
