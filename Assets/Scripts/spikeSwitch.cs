using UnityEngine;

public class spikeSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");

        if (other.CompareTag("Spike"))
        {
            other.GetComponentInParent<Spikes>().touchedByWall = true;

        }
    }
}
