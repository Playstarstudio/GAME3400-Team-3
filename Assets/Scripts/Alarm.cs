using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour
{
    public bool active;
    private float angl;
    private float angly;
    private float anglz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angl = transform.rotation.eulerAngles.x;
        angly = transform.rotation.eulerAngles.y;
        anglz = transform.rotation.eulerAngles.z;
        foreach (Light l in this.GetComponentsInChildren<Light>())
        {
            l.intensity = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.rotation = Quaternion.Euler(angl, angly, anglz);
            angl += 3.0f;
            foreach (Light l in this.GetComponentsInChildren<Light>())
            {
                l.intensity = 50;
            }
			StartDelay(10);
        }
    }

    public void Activate()
    {
        active = true;
    }

	public void Deactivate() 
	{
        active = false;
	foreach (Light l in this.GetComponentsInChildren<Light>())
        {
            l.intensity = 0;
        }
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
		Deactivate();
    }
}
