using UnityEngine;

public class Player_Controller_New : MonoBehaviour
{
    public float speed = 3.0f; // Speed at which the player moves
    public float rotationSpeed = 55.0f; // Speed at which the player rotates
    public float ascendDescendSpeed = 2.0f; // Speed for ascending and descending
    public float acceleration = 10.0f; // Acceleration when primary hand trigger is pressed

    private float currentVerticalSpeed = 0.0f;
    private bool isAccelerating = false;
    private bool isAscending = false;
    private bool isDescending = false;

    private void Update()
    {
        //-----------------------------------
        // Player Movement Code Begins
        //-----------------------------------

        // Get the forward direction of the player
        Vector3 forwardDirection = transform.forward;

        // Gather input from the right thumbstick for movement
        Vector2 movementThumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick); // Right-hand controller
        Vector3 moveDirection = (forwardDirection * movementThumbstick.y) + (transform.right * movementThumbstick.x);
        float moveMagnitude = Mathf.Clamp01(movementThumbstick.magnitude);

        // Move the player forward, backward, left, or right based on the direction they are facing
        Vector3 movement = moveDirection.normalized * speed * moveMagnitude * Time.deltaTime;

        // Accelerate in the specified direction when primary hand trigger (OVRInput.Button.PrimaryHandTrigger) on the right controller is pressed
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            isAccelerating = true;
        }
        else
        {
            isAccelerating = false;
        }

        if (isAccelerating)
        {
            movement *= acceleration;
        }

        transform.Translate(movement, Space.World);

        //-----------------------------------
        // Player Movement Code Ends
        //-----------------------------------

        //-----------------------------------
        // Ascend and Descend Code Begins
        //-----------------------------------

        // Continuous ascend when primary hand trigger (OVRInput.Button.PrimaryHandTrigger) on the left controller is pressed and held
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            isAscending = true;
        }
        else
        {
            isAscending = false;
        }

        // Continuous descend when primary index trigger (OVRInput.Button.PrimaryIndexTrigger) on the left controller is pressed and held
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            isDescending = true;
        }
        else
        {
            isDescending = false;
        }

        // Determine continuous ascend or descend
        if (isAscending)
        {
            currentVerticalSpeed = ascendDescendSpeed;
        }
        else if (isDescending)
        {
            currentVerticalSpeed = -ascendDescendSpeed;
        }
        else
        {
            currentVerticalSpeed = 0.0f;
        }

        // Apply the vertical movement to the player's position
        transform.Translate(Vector3.up * currentVerticalSpeed * speed * Time.deltaTime, Space.World);

        //-----------------------------------
        // Ascend and Descend Code Ends
        //-----------------------------------

        //-----------------------------------
        // Rotation Code Begins
        //-----------------------------------

        // Gather input from the left thumbstick for rotation
        Vector2 rotationThumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick); // Left-hand controller
        float rotateHorizontal = rotationThumbstick.x;

        // Rotate the player left or right based on the horizontal input from the left thumbstick
        float rotation = rotateHorizontal * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        //-----------------------------------
        // Rotation Code Ends
        //-----------------------------------
    }
}
