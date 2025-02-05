using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserManager : MonoBehaviour
{
    [SerializeField] private List<LaserArray> laserOrder = new List<LaserArray>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Activate()
    {
        
        for (int i = 0; i < laserOrder.Count; i++)
        {
            laserOrder[i].Activate();
			StartDelay(30);
			laserOrder[i].Deactivate();
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
		
    }
}
