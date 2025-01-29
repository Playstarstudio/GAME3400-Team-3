using System.Collections;
using UnityEngine;

public class RotatePendulum : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float limit = 25f;
    [SerializeField] private float startDelay;
    [SerializeField] bool go = false;

    private void Start()
    {
        StartCoroutine("delayStart");
    }
    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            float angle = limit * Mathf.Sin(Time.time * speed + startDelay);
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
            
    }

    IEnumerator delayStart()
    {
        yield return new WaitForSeconds(startDelay);
        go = true;
    }
}
