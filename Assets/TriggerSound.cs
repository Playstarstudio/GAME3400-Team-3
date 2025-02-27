using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource audioSource;


    private void OnTriggerEnter(Collider other) {
         audioSource.Play();   
    }
}
