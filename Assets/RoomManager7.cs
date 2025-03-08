using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManager7 : MonoBehaviour
{
    public bool hasGem;

    public List<GameObject> rainSystems; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasGem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasGem)
            toggleRain();
    }

    void toggleRain() {
        foreach (GameObject rain in rainSystems) {
            rain.SetActive(false);
        }
    }
}
