using UnityEngine;

public class AirlockBehavior : MonoBehaviour
{
    public GameObject[] ventSteam;
    public BoxCollider airlockTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < ventSteam.Length; i++) {
            ventSteam[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
