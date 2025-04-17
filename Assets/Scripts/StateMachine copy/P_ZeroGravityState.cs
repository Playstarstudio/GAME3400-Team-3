using UnityEngine;

public class P_ZeroGravityState : P_State
{
    public override void EnterState(P_StateManager player)
    {
        player.isInZeroGrav = true;
        player.characterController.enabled = false;

        player.rb.linearDamping = player.drag;
    }


    public override void UpdateState(P_StateManager player)
    {
        /*TO DO: 
        WASD = up down left right movement
        QE = roll left right
        Mouse movement = pitch/yaw
        Shift = speed up
        Space = brake
        
        if(PlayerControl.isGrabbing ==true)
        {
            player.SwitchState(player.grabbingState);
        }
       / */

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float rollInput = Input.GetKey(KeyCode.Q) ? -1f : Input.GetKey(KeyCode.E) ? 1f : 0f;
        //bool shiftHeld = Input.GetKey(KeyCode.LeftShift);
        bool wHeld = Input.GetKey(KeyCode.W);
        bool ctrlHeld = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        bool spaceHeld = Input.GetKey(KeyCode.Space);



        // Rotation (pitch, yaw, roll)
        float pitch = -mouseY * player.rotationSpeed * Time.deltaTime;
        float yaw = mouseX * player.rotationSpeed * Time.deltaTime;
        float roll = rollInput * player.rollSpeed * Time.deltaTime;
        //player.rb.transform.Rotate(pitch, yaw, roll, Space.Self);


       
        if (ctrlHeld)
        {
            player.rb.AddRelativeForce(-Vector3.up * player.acceleration * Time.deltaTime, ForceMode.Acceleration);
        }

        if (spaceHeld)
        {
            player.rb.AddRelativeForce(Vector3.up * player.acceleration * Time.deltaTime, ForceMode.Acceleration);
        }
        
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        if (moveDirection != Vector3.zero)
        {
            Debug.Log("MoveDirection: " + moveDirection); 
            //player.transform
            player.rb.AddRelativeForce(moveDirection * player.acceleration * Time.deltaTime, ForceMode.Acceleration);
        }
        // Drag
        ApplyDrag(player);


    }

    public override void ExitState(P_StateManager player)
    {
        player.isInZeroGrav = false;
    }

    private void ApplyDrag(P_StateManager player)
    {
        Vector3 velocity = player.rb.linearVelocity;
        Vector3 deceleration = -velocity.normalized * player.drag * Time.deltaTime;

        if (deceleration.magnitude > velocity.magnitude)
        {
            deceleration = -velocity;
        }

        player.rb.AddForce(deceleration, ForceMode.VelocityChange);
    }



}
