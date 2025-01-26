using System.Collections;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] float xMin = -45f;
    [SerializeField] float xMax = 45f;
    [SerializeField] float currentAngle;
    [SerializeField] float startDelay;
    [SerializeField] RoomManager roomManager;
    private float speed;
    [SerializeField] bool movingRight = false;
    [SerializeField] bool go = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = roomManager.pendulumSpeed;
        currentAngle = xMin;
        StartCoroutine("delayStart");
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = transform.rotation.x;
        if (go)
        {
            if (currentAngle >= xMax * .95f)
            {
                movingRight = true;
            }
            if (currentAngle <= xMin * .95f)
            {
                movingRight = false;
            }
            if (movingRight)
            {
                transform.rotation = new Quaternion(Mathf.Lerp(currentAngle, xMax, speed * Time.deltaTime),
                    transform.rotation.y, transform.rotation.z, transform.rotation.w);
            } 
            else
            {
                transform.rotation = new Quaternion(Mathf.Lerp(currentAngle, xMin, speed * Time.deltaTime),
                    transform.rotation.y, transform.rotation.z, transform.rotation.w);
            }
        }
    }
    IEnumerator delayStart()
    {
        yield return new WaitForSeconds(startDelay);
        go = true;
    }
}
