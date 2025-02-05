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
            lasers[i].Activate();
                
        }
    }

	public void Deactivate()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            //alarm.Stop();
            lasers[i].Deactivate();
                
        }
    }
}
