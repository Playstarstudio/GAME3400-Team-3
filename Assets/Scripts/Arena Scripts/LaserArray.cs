using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserArray : MonoBehaviour
{
    [Header ("Make sure that the laser matches \n" +
             "the light in the order of the list")]
    [SerializeField] private List<Laser> lasers = new List<Laser>();
    
    [SerializeField] private List<Alarm> alarms = new List<Alarm>();

    [SerializeField] private AudioSource alarm;
    

    public void Activate()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            //alarm.Play();
            alarms[i].Activate();
            StartDelay(2, i);
                
        }
    }

	public void Deactivate()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            //alarm.Stop();
            lasers[i].gameObject.SetActive(false);
                
        }
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
		lasers[index].gameObject.SetActive(true);
    }
}
