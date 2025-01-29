using Unity.VisualScripting;
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
        playerRigidbody.AddForce(player.transform.up * (knockbackForce / 4), ForceMode.Impulse);
        playerRigidbody.AddForce(-player.transform.forward * knockbackForce, ForceMode.Impulse);
        Debug.Log("Knockback");
    }
}