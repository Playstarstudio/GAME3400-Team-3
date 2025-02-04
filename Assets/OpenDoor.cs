using UnityEngine;
using UnityEngine.UI;
public class OpenDoor : MonoBehaviour
{
    public GameObject uiObject;

    private bool playerInRange;

    void Start()
    {
        uiObject.SetActive(false);
        playerInRange = false;
    }

    void OnTriggerEnter(Collider other)
    {
        playerInRange = true;
        if (other.CompareTag("Player"))
        {
            uiObject.SetActive(true);
        }

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            AnimateDoor();
        }

    }

    void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        if (other.CompareTag("Player"))
        {
            uiObject.SetActive(false);
        }
    }

    void AnimateDoor()
    {
        // Code to open the door goes here.
    }

}
