using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public Vector3 selfPos;
    public float rotationX = 0f;
    public float rotationY = 0f;
    public float rotationZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        selfPos = transform.position;
        rotationX = transform.position.x * 6000;
        rotationY = transform.position.y * 6000;
        rotationZ = transform.position.z * 6000;
        rotationX = Mathf.Abs(rotationX % 8) - 4;
        rotationY = Mathf.Abs(rotationY % 8) - 4;
        rotationZ = Mathf.Abs(rotationZ % 8) - 4;


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationX * Time.deltaTime * 2, rotationY * Time.deltaTime * 2, rotationZ * Time.deltaTime * 2);
    }
}
