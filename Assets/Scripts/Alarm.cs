using UnityEngine;

public class Alarm : MonoBehaviour
{
    public bool active;
    private float angl = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (active)
        {
            transform.rotation = Quaternion.Euler(angl, 0.0f, 0.0f);
            angl += 3.0f;
        }
    }
}
