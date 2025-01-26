using System;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    float yMin = -1.8f;
    float yMax = -1f;
    [SerializeField] float startDelay;
    [SerializeField] RoomManager roomManager;
    private float speed;
    bool movingUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = roomManager.spikeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 
            Mathf.Lerp(yMin, yMax, speed * Time.deltaTime),
            transform.position.z);
    }

    void toggleMovingUp()
    {
        movingUp = !movingUp;
    }
}
