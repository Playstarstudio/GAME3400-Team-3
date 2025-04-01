using UnityEngine;

public class GravityArea : MonoBehaviour
{
    public CharacterController controller;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (controller != null && rb != null)
        {
            controller.Gravity = 0.1f;
            rb.AddForce(Vector3.up, ForceMode.Acceleration);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (controller != null && rb != null)
        {
            controller.Gravity = -15f;
            rb.linearVelocity = Vector3.zero;
        }
    }
}
