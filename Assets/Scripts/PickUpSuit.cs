using UnityEngine;

public class PickUpSuit : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject suit;
    public P_StateManager playerManager;
    private bool playerInRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E)){
            playerManager.hasSuit = true;
            Destroy(suit);
            Destroy(uiObject);
            Destroy(this.gameObject);
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
}
