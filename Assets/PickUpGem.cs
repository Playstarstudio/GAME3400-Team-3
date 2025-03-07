using UnityEngine;
using UnityEngine.UI;

public class PickUpGem : MonoBehaviour
{
    public GameObject uiObject;
    [SerializeField] private GameObject completedStaff;
    [SerializeField] private RoomManager roomManager;
    [SerializeField] private GameObject playerStaff;
    private Transform staffTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        staffTransform = playerStaff.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")) {
            uiObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                SwapStaffs(playerStaff, completedStaff);
            }
        }
    }

    void OnTriggerExit(Collider collider) {
        if(collider.CompareTag("Player")) {
            uiObject.SetActive(false);
        }
    }

    void SwapStaffs(GameObject playerStaff, GameObject fullStaff) {
    GameObject completeStaff = Instantiate(fullStaff, playerStaff.transform.position, playerStaff.transform.rotation);
    Destroy(playerStaff);
    }
}
