using UnityEngine;

public class RotatePendulum : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float limit = 25f;
    

    // Update is called once per frame
    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time * speed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
