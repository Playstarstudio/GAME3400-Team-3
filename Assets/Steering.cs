using UnityEngine;

public class Steering : MonoBehaviour
{
    public float slideSpeed = 30f;
    public float maxSlideDistance = 5f;
    
    private float initialXPosition;
    private Rigidbody rb;
    
    void Start()
    {
        initialXPosition = transform.position.x;
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
        
        if (!Input.anyKeyDown) {
            rb.linearVelocity = Vector3.zero;
        }
        // Check if we're outside bounds regardless of input
        if (transform.position.x < initialXPosition - maxSlideDistance)
        {
            // If we're beyond the left boundary
            Vector3 position = transform.position;
            position.x = initialXPosition - maxSlideDistance;
            transform.position = position;
            
            // Stop movement in that direction
            Vector3 velocity = rb.linearVelocity;
            if (velocity.x < 0) velocity.x = 0;
            rb.linearVelocity = velocity;
        }
        else if (transform.position.x > initialXPosition + maxSlideDistance)
        {
            // If we're beyond the right boundary
            Vector3 position = transform.position;
            position.x = initialXPosition + maxSlideDistance;
            transform.position = position;
            
            // Stop movement in that direction
            Vector3 velocity = rb.linearVelocity;
            if (velocity.x > 0) velocity.x = 0;
            rb.linearVelocity = velocity;
        }
        
        // Apply steering force if there's input
        if (horizontalInput != 0)
        {
            // Use force for movement
            Vector3 movement = new Vector3(horizontalInput, 0,0 );
            rb.AddForce(movement * slideSpeed);
        }
    }
}
