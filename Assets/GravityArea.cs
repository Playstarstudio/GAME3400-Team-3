using UnityEngine;
using StarterAssets;

public class GravityArea : MonoBehaviour
{
    private float originalGravity;
    private FirstPersonController playerController;

    private void OnTriggerEnter(Collider other)
    {
        playerController = other.GetComponent<FirstPersonController>();
        if (playerController != null)
        {
            playerController.isGravityEnabled = false;
            playerController.Gravity = 1f;
            playerController.GetComponent<CharacterController>().Move(Vector3.up * 1f);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerController != null)
        {
            playerController.Gravity = -15f;
            playerController.isGravityEnabled = true;
        }
    }
}
