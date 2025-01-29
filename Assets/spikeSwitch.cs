using UnityEngine;

public class spikeSwitch : MonoBehaviour
{
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log("collision");

        if (other.gameObject.CompareTag("Spike"))
        {
            gameObject.GetComponentInParent<Spikes>().touchedByWall = true;

        }
    }
}
