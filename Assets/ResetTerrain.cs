using UnityEngine;

public class ResetTerrain : MonoBehaviour
{
    public Transform terrain;

    public TerrainManager manager;


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        manager.MoveTerrain();
    }
}
