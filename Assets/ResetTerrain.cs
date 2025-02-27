using UnityEngine;

public class ResetTerrain : MonoBehaviour
{
    public Transform terrain;


  

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        terrain.position = new Vector3(terrain.position.x, terrain.position.y, terrain.position.z + 500);
    }
}
