using UnityEngine;

public class OpenLocker : MonoBehaviour
{
    public GameObject lockerDoor;
    public GameObject uiObject;
    public GameObject suitTrigger;
    bool isOpen = false;
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            uiObject.SetActive(true);
            if(!isOpen) {
                lockerDoor.transform.Rotate(0, 90, 0);
                isOpen = true;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            uiObject.SetActive(false);
        }
    }
}
