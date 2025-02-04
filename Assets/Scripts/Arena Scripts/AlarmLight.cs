using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour
{
    private Renderer renderer;

    public float changeSpeed = 3f;

    public Color color1;
    public Color color2;

    public bool isActive;
    
    void Start()
    {
        renderer = GetComponent<Renderer>();
        isActive = false;
    }
    public void Activate()
    {
        isActive = true;
        float step = Mathf.PingPong(Time.time, changeSpeed);
        
    }

    void Update()
    {
        float step = Mathf.PingPong(Time.time, changeSpeed);
        if (isActive)
        {
            renderer.material.color = Color.Lerp(color1, color2, step);
        }

        StartDelay(30);
        isActive = false;
    }
    
    void StartDelay(float delayTime)
    {
        StartCoroutine(Delay(delayTime));
    }

    IEnumerator Delay(float delayTime)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);

        //Do the action after the delay time has finished.
    }
}
