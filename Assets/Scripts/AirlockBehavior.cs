using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.ProBuilder.Shapes;

public class AirlockBehavior : MonoBehaviour
{
    public GameObject[] ventSteam;
    public BoxCollider airlockTrigger;
    public AudioClip airlockClip;
    public P_StateManager player;
    public AudioSource audioSource;


    [Header("Enter Door Settings")]
    public OpenDoor enterDoor;
    public AudioClip noSuitChime;

    [Header("Exit Door Settings")]
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameObject endPosition;
    [SerializeField] private AudioClip openingSound;
    [SerializeField] private AudioClip closingSound;
    private AudioSource exitDoorAudioSource;
    private bool hasPlayedOpenSound = false;
    private bool hasPlayedCloseSound = false;
    private Transform startPosn;
    private Transform endPosn;
    public float speed = 5f;
    private bool isOpening = false;
    private bool isClosing = false;
    private bool hasPlayedNoSuitChime = false;
    private bool isInAirLock = false;
    private bool hasVented = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < ventSteam.Length; i++) {
            ventSteam[i].SetActive(false);
        }
        exitDoorAudioSource = exitDoor.GetComponent<AudioSource>();
        startPosn = startPosition.transform;
        endPosn = endPosition.transform;
        exitDoor.transform.position = startPosn.position;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.volume = 0.5f;
        audioSource.playOnAwake = false;
        hasVented = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.hasSuit && isInAirLock)
        {
            enterDoor.isOpening = true;
        }
        if (player.hasSuit && hasVented && isInAirLock)
        {
            isOpening = true;
            isClosing = false;
        }
        else
        {
            isClosing = true;
            isOpening = false;
        }
            OpenExitDoor();
    }

    public IEnumerator VentSteam() {
        if (!hasVented)
        {
            AudioSource.PlayClipAtPoint(airlockClip, player.transform.position, 0.5f);
            for (int i = 0; i < ventSteam.Length; i++)
            {
                ventSteam[i].SetActive(true);
            }
            yield return new WaitForSeconds(1);
            for (int i = 0; i < ventSteam.Length; i++)
            {
                ventSteam[i].SetActive(false);
            }
            yield return new WaitForSeconds(1);
            hasVented = true;
        }
    }

    public void OpenExitDoor()
    {
        if (isOpening)
        {
            if (!hasPlayedOpenSound)
            {
                exitDoorAudioSource.PlayOneShot(openingSound);
                Debug.Log("Played: opening Audio");
                hasPlayedOpenSound = true;
                hasPlayedCloseSound = false;
            }
            exitDoor.transform.position = Vector3.MoveTowards(
                exitDoor.transform.position,
                endPosn.position,
                speed * Time.deltaTime
            );
            if (exitDoor.transform.position == endPosn.position)
            {
                isOpening = false;
            }
        }
        if (isClosing)
        {
            if (!hasPlayedCloseSound)
            {

                exitDoorAudioSource.PlayOneShot(closingSound);
                Debug.Log("Played: closing Audio");
                hasPlayedCloseSound = true;
                hasPlayedOpenSound = false;
            }
            exitDoor.transform.position = Vector3.MoveTowards(
                exitDoor.transform.position,
                startPosn.position,
                speed * Time.deltaTime
            );
            if (exitDoor.transform.position == startPosn.position)
            {
                isClosing = false;
            }
        }
    }

    public IEnumerator AirLockSequence()
    {
        if(player.hasSuit)
        {
            yield return new WaitForSeconds(0.25f);
            StartCoroutine(VentSteam());
            
        }
        else if(!hasPlayedNoSuitChime && !player.hasSuit)
        {
            yield return new WaitForSeconds(0.25f);
            audioSource.PlayOneShot(noSuitChime);
            Debug.Log("Played: no suit Audio");
            hasPlayedNoSuitChime = true;
            enterDoor.isOpening = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<P_StateManager>();
            isInAirLock = true;
            StartCoroutine(AirLockSequence());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           enterDoor.isOpening = false;
           isInAirLock = false;
            hasPlayedNoSuitChime = false;
        }
    }
}
