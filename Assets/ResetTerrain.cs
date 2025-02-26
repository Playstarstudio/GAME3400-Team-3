using UnityEngine;

public class ResetTerrain : MonoBehaviour
{
    public GameObject terrain;

    private Vector3 resetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetPosition = terrain.transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        terrain.transform.position = resetPosition;
    }
}
