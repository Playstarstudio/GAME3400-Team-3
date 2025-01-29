using UnityEngine;

public class PickUpDaRok : MonoBehaviour
{
    [SerializeField] private RoomManager _roomManager;
    [SerializeField] private GameObject daRok;
    [SerializeField] private Collider rockCollider;

    [SerializeField] private GameObject bagpipes;
    [SerializeField] private GameObject player;

    private Transform rockPosition;

    void Start()
    {
        rockPosition = daRok.transform;
    }

    void OnTriggerEnter(Collider collider)
    {
        PickUpRok();
    }

    void PickUpRok()
    {
        Destroy(daRok);
        DropBagpipes();
        _roomManager.hasStone = true;
    }
    
    void DropBagpipes()
    {
        Instantiate(bagpipes, rockPosition.position, Quaternion.identity);
    }
}