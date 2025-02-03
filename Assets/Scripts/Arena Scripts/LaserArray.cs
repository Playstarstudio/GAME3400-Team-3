using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserArray : MonoBehaviour
{
    [Header ("Make sure that the laser matches \n" +
             "the light in the order of the list")]
    [SerializeField] private List<Laser> lasers = new List<Laser>();
    
    [SerializeField] private List<AlarmLight> lights = new List<AlarmLight>();

    public void Activate()
    {
        for (int i = 0; i < lasers.Count; i++)
        {
            lasers[i].Activate();
            lights[i].Activate();
            if (i == lasers.Count - 1)
            {
                i = 0;
            }
                
        }
    }
}
