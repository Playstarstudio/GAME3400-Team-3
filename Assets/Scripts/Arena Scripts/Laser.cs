using UnityEngine;

public class Laser : MonoBehaviour
{
	
	void Start() 
	{
        gameObject.SetActive(false);
    }

    void Update()
    {
        // Update the laser position and rotation
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }
}
