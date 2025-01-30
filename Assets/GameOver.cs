using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private RoomManager roomManager;
    private Collider playerCollider;

    void OnTriggerEnter(Collider collider)
    {
        if (roomManager.hasStone)
        {
            Debug.Log("Won");
            SceneManager.LoadScene("Game Over");
        }
    }
}
