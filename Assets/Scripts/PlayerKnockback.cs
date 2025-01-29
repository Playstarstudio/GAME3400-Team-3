using UnityEngine;
using System.Collections;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private float knockbackDuration = 0.2f;
    [SerializeField] private Rigidbody playerRigidbody;
    private bool isKnockedBack = false;
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard") && !isKnockedBack)
        {
            Vector3 direction = (transform.position - collision.transform.position).normalized;
            ApplyKnockback(direction);
        }
    }

    private void ApplyKnockback(Vector3 direction)
    {
        isKnockedBack = true;
        
        // Add upward force component
        Vector3 knockbackDirection = (direction + Vector3.up).normalized;
        playerRigidbody.linearVelocity = Vector3.zero; // Reset velocity first
        playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        
        StartCoroutine(ResetKnockback());
    }

    private IEnumerator ResetKnockback()
    {
        yield return new WaitForSeconds(knockbackDuration);
        isKnockedBack = false;
    }
}

