using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    private Renderer renderer;

    public float changeSpeed = 3f;

    public Color color1;
    public Color color2;
    
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void Activate()
    {
        float step = Mathf.PingPong(Time.time, changeSpeed);
        renderer.material.color = Color.Lerp(color1, color2, step);
    }
}
