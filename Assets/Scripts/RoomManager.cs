using Unity.Hierarchy;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public bool hasStone;
    public float spikeSpeed;
    public float speedMult;
    public float pendulumSpeed;
    bool spedUp = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upTheAnte();
    }

    private void upTheAnte()
    {
        if (hasStone && spedUp == false)
        {
            spikeSpeed = spikeSpeed * speedMult;
            pendulumSpeed = pendulumSpeed * speedMult;
            spedUp = true;
        }
    }
}
