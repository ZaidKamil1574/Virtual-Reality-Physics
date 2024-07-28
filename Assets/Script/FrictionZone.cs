using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FrictionZone : MonoBehaviour
{
    [Tooltip("Coefficient of friction applied to objects within this zone.")]
    public float frictionCoefficient = 0.1f;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            // Apply friction
            Vector3 frictionForce = -rb.velocity * frictionCoefficient;
            rb.AddForce(frictionForce, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            // Stop the object if it comes to a near stop
            if (rb.velocity.magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    private void Reset()
    {
        // Ensure the collider is a trigger
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }
}

