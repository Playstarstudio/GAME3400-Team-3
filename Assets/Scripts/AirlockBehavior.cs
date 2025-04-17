using System.Collections;
using UnityEngine;

public class AirlockBehavior : MonoBehaviour
{
    public GameObject[] ventSteam;
    public BoxCollider airlockTrigger;
    public AudioClip airlockClip;
    public P_StateManager player;
    [Header("Exit Door Settings")]
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameObject endPosition;
    private Transform startPosn;
    private Transform endPosn;
    public float speed = 5f;
    private bool isOpening = false;
    private bool isClosing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < ventSteam.Length; i++) {
            ventSteam[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator VentSteam() {
        AudioSource.PlayClipAtPoint(airlockClip, player.transform.position);
        for(int i = 0; i < ventSteam.Length; i++) {
            ventSteam[i].SetActive(true);
            yield return new WaitForSeconds(1);
            ventSteam[i].SetActive(false);
        }
    }

    public void AirLockSequence()
    {
        if(player.hasSuit)
        {

        }
    }
}
