using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public GameObject uiObject;
    private bool playerInRange;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameObject endPosition;
    private Transform startPosn;
    private Transform endPosn;
    public float speed = 5f;
    private bool isOpening = false;
    private bool isClosing = false;

    void Start()
    {
        playerInRange = false;
        startPosn = startPosition.transform;
        endPosn = endPosition.transform;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            isOpening = true;
            isClosing = false; 
        }

        if (isOpening)
        {
            door.transform.position = Vector3.MoveTowards(
                door.transform.position, 
                endPosn.position, 
                speed * Time.deltaTime
            );
        }
        if (isClosing)
        {
            door.transform.position = Vector3.MoveTowards(
                door.transform.position, 
                startPosn.position, 
                speed * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            uiObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            uiObject.SetActive(false);
			isOpening = false;
            isClosing = true;
        }
    }
}
