using UnityEngine;

public class TriggerLaser : MonoBehaviour
{
    [SerializeField] private LaserManager laserManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            laserManager.Activate();
        }
    }
}
