using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerLoc;
    [SerializeField] private float speed = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToTarget = playerLoc.position - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(dirToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, speed * Time.deltaTime);
    }
}
