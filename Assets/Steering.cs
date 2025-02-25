using UnityEngine;

public class Steering : MonoBehaviour
{
    public float slideSpeed = 30f;
    public float maxSlideDistance = 5f;
    
    private float initialZPosition;
    private Rigidbody rb;
    
    void Start()
    {
        initialZPosition = transform.position.z;
        rb = GetComponent<Rigidbody>();
        
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing! Please add a Rigidbody to this GameObject.");
            enabled = false;
        }
    }
    
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Check if we're outside bounds regardless of input
        if (transform.position.z < initialZPosition - maxSlideDistance)
        {
            // If we're beyond the left boundary
            Vector3 position = transform.position;
            position.z = initialZPosition - maxSlideDistance;
            transform.position = position;
            
            // Stop movement in that direction
            Vector3 velocity = rb.linearVelocity;
            if (velocity.z < 0) velocity.z = 0;
            rb.linearVelocity = velocity;
        }
        else if (transform.position.z > initialZPosition + maxSlideDistance)
        {
            // If we're beyond the right boundary
            Vector3 position = transform.position;
            position.z = initialZPosition + maxSlideDistance;
            transform.position = position;
            
            // Stop movement in that direction
            Vector3 velocity = rb.linearVelocity;
            if (velocity.z > 0) velocity.z = 0;
            rb.linearVelocity = velocity;
        }
        
        // Apply steering force if there's input
        if (horizontalInput != 0)
        {
            // Use force for movement
            Vector3 movement = new Vector3(0, 0, horizontalInput);
            rb.AddForce(movement * slideSpeed);
        }
    }
}
