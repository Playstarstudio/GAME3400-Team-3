using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_StateManager : MonoBehaviour
{

    #region States
    public P_State currentState;
    public P_State previousState;
    public P_Walking walkingState = new P_Walking();
    public P_ZeroGravityState zeroGravState = new P_ZeroGravityState();
    #endregion

    #region Components
    public Rigidbody rb;
    public CharacterController characterController;
    public Transform groundedObject;
    public Transform mainCamera;
    public Quaternion groundedPlayerRotation;
    public Quaternion groundedCameraRotation;
    public Animator anim;

    public AudioSource breathingAudioSource;
    public AudioSource backgroundMusicAudioSource;
    public AudioSource otherSoundsAudioSource;

    public AudioClip jetPackAirSoundClip;
    public AudioClip[] breathingClips;
    public AudioClip[] backgroundMusicClips;
    public AudioClip landingClip, jumpClip;

    #endregion

    #region Movement Variables
    public float moveSpeed = 10f;
    public float rotationSpeed = 500f;
    public float rollSpeed = 50f;
    public float acceleration = 50f;
    public float drag = 0.2f;
    #endregion

    #region Resource Variables
    public float boostMult = 0f;
    public bool isWalking = false;
    public bool isInZeroGrav = false;

    public bool isBoosting = false;
    #endregion

    #region UI Elements
    public CanvasGroup fadePanel;
    #endregion


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        currentState = walkingState;

        currentState.EnterState(this);
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        mainCamera = transform.Find("Main Camera");

        
        // Initialize audio sources
        breathingAudioSource = gameObject.AddComponent<AudioSource>();
        breathingAudioSource.loop = false;
        breathingAudioSource.volume = 0.075f;

        backgroundMusicAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicAudioSource.loop = false;
        backgroundMusicAudioSource.volume = 0.2f;

        otherSoundsAudioSource = gameObject.AddComponent<AudioSource>();
        otherSoundsAudioSource.loop = false;

//        StartCoroutine(PlayBreathingSound());
 //       StartCoroutine(PlayBackgroundMusic());

        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found as a child of the player!");
            return;
        }
    }

    private void Update()
    {
        currentState.UpdateState(this);
        

        // Lock Camera Rotation on Z-axis
        if (mainCamera != null)
        {
            Quaternion currentRotation = mainCamera.localRotation;
            mainCamera.localRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, 0f);
        }

    }


    public void SwitchState(P_State state)
    {
        Debug.Log($"Switching to {state.GetType().Name}");
        currentState.ExitState(this);
        previousState = currentState;
        currentState = state;
        state.EnterState(this);
    }

    public void SwitchToPreviousState()
    {
        if (previousState != null)
        {
            SwitchState(previousState);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    /// <summary>
    /// Public method to set power.
    /// </summary>
    /// <param name="amount">New power value.</param>
    /// 
    /*
    public void SetPower(float amount)
    {
        power = Mathf.Clamp(amount, 0f, 100f); // Ensure power stays within 0-100
    }
    */

    

  

    
    private IEnumerator PlayBreathingSound()
    {
        while (true)
        {
            breathingAudioSource.clip = breathingClips[Random.Range(0, breathingClips.Length)];
            breathingAudioSource.Play();

            yield return new WaitForSeconds(breathingAudioSource.clip.length);
        }
    }

    private IEnumerator PlayBackgroundMusic()
    {
        while (true)
        {

            backgroundMusicAudioSource.clip = backgroundMusicClips[Random.Range(0, 2)];
            backgroundMusicAudioSource.Play();

            while (backgroundMusicAudioSource.isPlaying)
            {
                yield return null;
            }
        }
    }


    public void PlaySound(string soundName)
    {
        AudioClip clip = null;

        switch (soundName)
        {
            case "Landing":
                otherSoundsAudioSource.volume = .3f;
                clip = landingClip;
                break;
            case "Jump":
                otherSoundsAudioSource.volume = .3f;
                clip = jumpClip;
                break;
        }

        if (clip != null)
        {
            otherSoundsAudioSource.PlayOneShot(clip);
        }
    }
}
