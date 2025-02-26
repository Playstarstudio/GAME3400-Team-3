using System.Collections;
using UnityEngine;

public class CarShaker : MonoBehaviour
{
    public bool isShaking = false;
    public float timeDelay;
    public float shakeMin;
    public float shakeMax;
    void Update()
    {
        if (isShaking == false)
        {
            StartCoroutine(ShakingCar());
        }

    }


    IEnumerator ShakingCar()
    {
        isShaking = true;
        Vector3 currentPos = new Vector3(transform.position.x, Random.Range(shakeMin, shakeMax), transform.position.z);
        timeDelay = Random.Range(.01f, .05f);
        transform.position = currentPos;
        yield return new WaitForSeconds(timeDelay);
        currentPos = new Vector3(transform.position.x, Random.Range(shakeMin, shakeMax), transform.position.z);
        timeDelay = Random.Range(.01f, .05f);
        transform.position = currentPos;
        yield return new WaitForSeconds(timeDelay);
        isShaking = false;
    }
}
