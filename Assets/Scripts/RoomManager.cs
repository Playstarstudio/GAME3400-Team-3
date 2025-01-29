using Unity.Hierarchy;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public bool hasStone;
    public float spikeSpeed;
    public float speedMult;
    public float pendulumSpeed;
    bool spedUp = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (hasStone && spedUp == false)
            upTheAnte();
    }

    private void upTheAnte()
    {
        spikeSpeed = spikeSpeed * speedMult;
        pendulumSpeed = pendulumSpeed * speedMult;
        spedUp = true;
    }
}
