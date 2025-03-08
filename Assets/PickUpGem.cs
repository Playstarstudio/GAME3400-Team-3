using UnityEngine;
using UnityEngine.UI;

public class PickUpGem : MonoBehaviour
{
    public GameObject uiObject;
    [SerializeField] private GameObject completedStaff;
    [SerializeField] private RoomManager7 roomManager;
    [SerializeField] private GameObject playerStaff;
    private Transform staffTransform;

    private bool playerInRange;

    [SerializeField] private GameObject gemstone;
    [SerializeField] private GameObject trigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        staffTransform = playerStaff.transform;
        playerInRange = false;
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            SwapStaffs(playerStaff, completedStaff);
            Destroy(gemstone);
            Destroy(uiObject);
            roomManager.hasGem = true;
            //Disables script
            Destroy(trigger);
        }

    }

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            playerInRange = true;
            uiObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.CompareTag("Player")) {
            playerInRange = false;
            uiObject.SetActive(false);
        }
    }

    void SwapStaffs(GameObject playerStaff, GameObject fullStaff) {
    GameObject completeStaff = Instantiate(fullStaff, playerStaff.transform.position, playerStaff.transform.rotation);
    completeStaff.transform.SetParent(playerStaff.transform.parent);
    DestroyImmediate(playerStaff, true);
    }
}
