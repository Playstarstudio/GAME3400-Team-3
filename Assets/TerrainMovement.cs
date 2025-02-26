using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    private Vector3 initialPosition;

    //public GameObject loopTrigger;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update()
    {
        Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position - movement);

    }

}

