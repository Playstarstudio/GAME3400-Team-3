using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private Collider hazardCollider;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody playerRigidbody; 
    [SerializeField] private float knockbackForce = 250f;
    
    void Start()
    {
        Debug.Log(hazardCollider);
        playerRigidbody = player.GetComponent<Rigidbody>(); 
    }
    
    void OnTriggerEnter(Collider collision)
    {
        KnockbackPlayer();
    }

    private void KnockbackPlayer()
    {
        playerRigidbody.AddForce(Vector3.up * (knockbackForce / 4), ForceMode.Impulse);
        playerRigidbody.AddForce(Vector3.back * knockbackForce, ForceMode.Impulse);
        Debug.Log("Knockback");
    }
}