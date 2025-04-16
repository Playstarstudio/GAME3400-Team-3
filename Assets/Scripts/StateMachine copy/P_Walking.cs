using UnityEngine;

public class P_Walking : P_State
{
    float speed;
    public float jumpHeight = 0f;
    public float gravity = 9.81f;

    public float airControl = 10f;

    Vector3 input;
    Vector3 moveDirection;
    CharacterController controller;

    Transform transform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EnterState(P_StateManager player)
    {
        player.rb.linearVelocity = Vector3.zero;
        player.rb.isKinematic = true;
        player.isWalking = true;
        player.characterController.enabled = true;
        speed = player.moveSpeed;
        controller = player.characterController;
        transform = player.transform;
    }

    public override void UpdateState(P_StateManager player)
    {
        Move();
    }

    public override void ExitState(P_StateManager player)
    {
        player.isWalking = false;
        player.characterController.enabled = false;
    }

    private void Move()
	{
    
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = transform.right * moveHorizontal + transform.forward * moveVertical;
        input.Normalize();

        if(controller.isGrounded) {
            moveDirection = input;

            if (Input.GetButton("Jump")) {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
            else {
                moveDirection.y = 0.0f;
            }
        }
        else {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
    
}
