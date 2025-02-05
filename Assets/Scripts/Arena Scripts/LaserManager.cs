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
        TurnOnLaserWall(0);
		StartDelay(5, 0); 
    }

    public void TurnOnLaserWall(int laserIndex) 
	{
		laserOrder[laserIndex].Activate();
    }

    void StartDelay(float delayTime, int index)
    {
        StartCoroutine(Delay(delayTime, index));
    }

    IEnumerator Delay(float delayTime, int index)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        //Do the action after the delay time has finished.
		laserOrder[index].Deactivate();
    }
}
