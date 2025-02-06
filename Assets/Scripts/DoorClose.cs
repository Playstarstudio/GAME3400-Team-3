using UnityEngine;
using System.Collections;
public class DoorClose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator doorAnimator; // connect door controller
    public DoorTrigger doorController; // connect doorTrigger script
    public BoxCollider boxCollider;
    private void OnTriggerEnter(BoxCollider boxCollider)
    {
        // when player enter it will close
        if (boxCollider.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Close");
            doorController.SetCanOpen(false); // set unactive
        }
    }
    
}
