using UnityEngine;

public class OpenLocker : MonoBehaviour
{
    public GameObject lockerDoor;
    public GameObject uiObject;
    public GameObject suitTrigger;
    bool isOpen = false;
    bool playerInRange = false;

    private void Start() {
        uiObject.SetActive(false);
        suitTrigger.SetActive(false);
    }

    void Update() {
        if(playerInRange && Input.GetKeyDown(KeyCode.E)) {
            isOpen = true;
            lockerDoor.transform.Rotate(0, 90, 0);
            suitTrigger.SetActive(true);
        }
        if(isOpen) {
            Destroy(uiObject);
            Destroy(this.gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            uiObject.SetActive(true);
            playerInRange = true;            
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            playerInRange = false;
            uiObject.SetActive(false);
        }
    }
}
