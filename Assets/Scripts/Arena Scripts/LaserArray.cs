using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserArray : MonoBehaviour
{
    [Header ("Make sure that the laser matches \n" +
             "the light in the order of the list")]
    [SerializeField] private List<Laser> lasers = new List<Laser>();
    
    [SerializeField] private List<AlarmLight> lights = new List<AlarmLight>();

    [SerializeField] private AudioSource alarm;
    

    public void Activate()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            //alarm.Play();
            lights[i].Activate();
            lasers[i].Activate();
                
        }
    }
}
