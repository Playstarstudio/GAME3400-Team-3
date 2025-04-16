using UnityEngine;

public class ToggleGravity : MonoBehaviour
{
    BoxCollider boxCollider;
    P_StateManager player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            player = other.GetComponent<P_StateManager>();
            player.SwitchState(player.zeroGravState);
        }
    }
}
