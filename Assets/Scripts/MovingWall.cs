using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public bool isTouchingPlayer;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody playerRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerRigidbody)
        {
            isTouchingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == playerRigidbody)
        {
            isTouchingPlayer = true;
        }
    }
}
