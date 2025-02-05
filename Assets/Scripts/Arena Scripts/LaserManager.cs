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
        
        for (int i = 0; i < laserOrder.size(); i++)
        {
            laserOrder[i].Activate();
                
        }
        
    }
}
