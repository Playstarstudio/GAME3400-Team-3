using UnityEngine;
using TMPro;

public class UpdateScreenText : MonoBehaviour
{
    public TMP_Text screenText;
    public BoxCollider airlockTrigger;
    P_StateManager player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(string text, Color color) {
        screenText.text = text;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            player = other.GetComponent<P_StateManager>();
        }
        if(player != null) {
            if(player.hasSuit) {
                UpdateText("WARNING: NO OXYGEN AHEAD SPACE SUIT REQUIRED", Color.green);
            }
            else {
                UpdateText("WARNING: NO OXYGEN AHEAD SPACE SUIT REQUIRED", Color.red);
            }
        }


    }
}
