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
    }

    public void TurnOnLaserWall(int laserIndex) 
	{
		if (laserIndex == laserOrder.Count) 
         	{
           laserIndex = 0;
			}
		laserOrder[laserIndex].Activate();
		StartDelay(5, laserIndex, laserIndex + 1); 
    }

    void StartDelay(float delayTime, int index, int nextIndex)
    {
        StartCoroutine(Delay(delayTime, index, nextIndex));
    }

    IEnumerator Delay(float delayTime, int index, int nextIndex)
    {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        //Do the action after the delay time has finished.
		laserOrder[index].Deactivate();
        TurnOnLaserWall(nextIndex);
    }
}
