using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spinner : MonoBehaviour
{
    private float yRot;
    public float rotSpeed;
    public Quaternion rotation;
    void Start()
    {
        yRot = transform.rotation.y;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotSpeed,rotSpeed*3, rotSpeed, Space.Self);
    }
}
