using UnityEngine;

public class AdjustCenterOfMass : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.centerOfMass = new Vector3(0, -0.5f, 0); // Adjust Y value as needed
        }
    }
}

