using UnityEngine;

public class Alarm : MonoBehaviour
{
    public bool active;
    private float angl;
    private float angly;
    private float anglz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angl = transform.rotation.eulerAngles.x;
        angly = transform.rotation.eulerAngles.y;
        anglz = transform.rotation.eulerAngles.z;
        foreach (Light l in this.GetComponentsInChildren<Light>())
        {
            l.intensity = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.rotation = Quaternion.Euler(angl, angly, anglz);
            angl += 3.0f;
            foreach (Light l in this.GetComponentsInChildren<Light>())
            {
                l.intensity = 50;
            }
        }
    }

    public void Activate()
    {
        active = true;
    }
}
