using UnityEngine;
using System.Collections;
public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator; // set door animation
    public bool canOpen = true;
    void Update()
    {
       
        if (canOpen && Input.GetKeyDown(KeyCode.E))
        {
            doorAnimator.SetTrigger("Open");
        }
    }
    public void SetCanOpen(bool value)
    {
        canOpen = value;
    }
}
