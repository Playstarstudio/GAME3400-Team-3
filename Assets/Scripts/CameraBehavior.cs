using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float minPitch = -90f;
    public float maxPitch = 90f;

    public Transform playerBody;

    float pitch;
    void Start()
    {
     Cursor.visible = false;
     Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
{
    float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


    if (playerBody)
    {
        playerBody.Rotate(Vector3.up * moveX);
    }

    pitch -= moveY;
    pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    transform.localRotation = Quaternion.Euler(pitch, 0, 0);
}


}
