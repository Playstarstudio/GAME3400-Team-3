using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject uiObject;
    private bool playerInRange;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameObject endPosition;
    [SerializeField] private AudioClip openingSound;
    [SerializeField] private AudioClip closingSound;
    private Transform startPosn;
    private Transform endPosn;
    public float speed = 5f;
    public bool isOpening = false;
    public bool isClosing = false;

    private AudioSource audioSource;
    private bool hasPlayedOpenSound = false;
    private bool hasPlayedCloseSound = false;
    private bool wasOpening = false;
    private bool wasClosing = false;

    void Start()
    {
        if(uiObject)
            uiObject.SetActive(false);

        playerInRange = false;
        startPosn = startPosition.transform;
        endPosn = endPosition.transform;
        door.transform.position = startPosn.position;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.volume = 0.5f;
    }

    void Update()
    {

        if (isOpening && !wasOpening)
        {
            hasPlayedOpenSound = false;
            wasOpening = true;
        }
        else if (!isOpening)
        {
            wasOpening = false;
        }


        if (isClosing && !wasClosing)
        {
            hasPlayedCloseSound = false;
            wasClosing = true;
        }
        else if (!isClosing)
        {
            wasClosing = false;
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpening)
            {
                isOpening = true;
                isClosing = false;
            }
        }

        if (isOpening)
        {
            if (!hasPlayedOpenSound)
            {
                audioSource.PlayOneShot(openingSound);
                Debug.Log("Played: opening Audio");
                hasPlayedOpenSound = true;
            }
            door.transform.position = Vector3.MoveTowards(
                door.transform.position,
                endPosn.position,
                speed * Time.deltaTime
            );
            if (door.transform.position == endPosn.position)
            {
                isOpening = false;
            }
        }

        if (isClosing)
        {
            if (!hasPlayedCloseSound)
            {
                audioSource.PlayOneShot(closingSound);
                Debug.Log("Played: closing Audio");
                hasPlayedCloseSound = true;
            }
            door.transform.position = Vector3.MoveTowards(
                door.transform.position,
                startPosn.position,
                speed * Time.deltaTime
            );
            if (door.transform.position == startPosn.position)
            {
                isClosing = false;
            }
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
            hasPlayedCloseSound = false;
        }
    }
}
