using Unity.VisualScripting;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    [SerializeField] RoomManager roomManager;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] bool hasStone;
    [SerializeField] float wallSpeed;
    [SerializeField] float rightPosition;
    [SerializeField] float leftPosition;
    [SerializeField] private MovingWall rightWall;
    [SerializeField] private MovingWall leftWall;
    private BoxCollider rightCollider;
    private BoxCollider leftCollider;
    [SerializeField] bool moveIn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveIn = true;
        rightWall = this.GetComponentsInChildren<MovingWall>()[0];
        leftWall = this.GetComponentsInChildren<MovingWall>()[1];
        rightCollider = rightWall.GetComponent<BoxCollider>();
        leftCollider = leftWall.GetComponent<BoxCollider>();
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hasStone = roomManager.hasStone;
        rightPosition = rightWall.transform.position.x;
        leftPosition = leftWall.transform.position.x;
        if (hasStone)
        {
            Crush();
        }
    }

    void Crush()
    {
        if (moveIn)
        {
            rightWall.transform.position = new Vector3(rightWall.transform.position.x - (wallSpeed * Time.deltaTime),
                rightWall.transform.position.y, rightWall.transform.position.z);
            leftWall.transform.position = new Vector3(leftWall.transform.position.x + (wallSpeed * Time.deltaTime),
                leftWall.transform.position.y, leftWall.transform.position.z);
        }
        if (rightCollider.bounds.Intersects(leftCollider.bounds))
        {
            moveIn = false;
        }
        if (rightWall.isTouchingPlayer || leftWall.isTouchingPlayer)
        {
            Debug.Log("You lose!");
        }
    }
}
