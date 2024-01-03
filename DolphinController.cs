using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DolphinController : MonoBehaviour
{
    public float speed = 3.0f; // Speed at which the player moves

    private void Update()
    {
        // Action Buttons on Right Controller
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            // Insert the action to be performed when the button is pressed
        }


        //-----------------------------------
        // Player Movement Code Begins
        //-----------------------------------

        // Gather input from the right thumbstick for movement
        Vector2 movementThumbstick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick); // Right-hand controller
        float moveHorizontal = movementThumbstick.x;
        float moveVertical = movementThumbstick.y;

        // Calculate the movement direction based on thumbstick input
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Gather input from the left thumbstick for rotation
        Vector2 rotationThumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick); // Left-hand controller
        float rotateHorizontal = rotationThumbstick.x;

        // Define the four cardinal directions in degrees
        float[] cardinalDirections = { 0f, 180f, 90f, -90f };
        float closestAngle = Mathf.Round(transform.eulerAngles.y / 90) * 90f;

        // Snap rotation to the nearest cardinal direction
        float targetAngle = closestAngle;
        if (Mathf.Abs(rotateHorizontal) > 0.5f)
        {
            // If the left thumbstick is moved significantly, adjust the target angle
            targetAngle += rotateHorizontal > 0 ? 90f : -90f; // Change angle based on thumbstick input
        }

        // Set the player's rotation to the nearest cardinal direction
        transform.rotation = Quaternion.Euler(0, targetAngle, 0);

        //-----------------------------------
        // Player Movement Code Ends
        //-----------------------------------
    }
}

