using UnityEngine;
//This code is to make the camera(player move) , parts of this code were AI generated
//By Bing AI using GPT-4, the code had some errors that we edited and fixed 
// We also played with and modified the sensitivity values and came up with values that seemed 
//comfortable for the user

/* PS: we did not want the code to give rigid movement so we modified the AI 
 Generated code and added some parts of code from GitHub( @FreyaHomer )
The implementation is very similar to that of a flying object .*/

/* W A S D to move horizontally , Lshift to go up , Lcontrol to go down
 Focus mode enable -esc, Focus mode disable -left click mouse*/

[RequireComponent(typeof(Camera))]
public class Camera_move : MonoBehaviour
{
    public float acceleration = 15; // how fast you accelerate
    public float accSprintMultiplier = 4; // how much faster you go when "sprinting"
    public float lookSensitivity = 1; // mouse look sensitivity
    public float dampingCoefficient = 5; // how quickly you break to a halt after you stop your input
    public bool focusOnEnable = true; // whether or not to focus and lock cursor immediately on enable

    Vector3 velocity; // current velocity

    static bool Focused //This is a property 
    {
        get => Cursor.lockState == CursorLockMode.Locked;
        set
        {
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;//Shorthand if-else
            Cursor.visible = (value == false);//Visible if value is false
        }
    }

    void OnEnable()
    {
        if (focusOnEnable)
            Focused = true;
    }

    void OnDisable() => Focused = false;

    void Update()
    {
        // Input
        if (Focused)
            UpdateInput();
        else if (Input.GetMouseButtonDown(0))
            Focused = true;

        // Physics
        //Calculates velocity value
        velocity = Vector3.Lerp(velocity, Vector3.zero, dampingCoefficient * Time.deltaTime);

        //Transforms position by the velocity value
        transform.position += velocity * Time.deltaTime;
    }

    void UpdateInput()
    {
        // Position
        velocity += GetAccelerationVector() * Time.deltaTime;

        // Rotation
        Vector2 mouseDelta = lookSensitivity * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        Quaternion rotation = transform.rotation;
        Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
        Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);
        transform.rotation = horiz * rotation * vert;

        // Leave cursor lock
        if (Input.GetKeyDown(KeyCode.Escape))
            Focused = false;
    }

    Vector3 GetAccelerationVector()
    {
        Vector3 moveInput = default;

        void AddMovement(KeyCode key, Vector3 dir)
        {
            if (Input.GetKey(key))
                moveInput += dir;
        }

        AddMovement(KeyCode.W, Vector3.forward);
        AddMovement(KeyCode.S, Vector3.back);
        AddMovement(KeyCode.D, Vector3.right);
        AddMovement(KeyCode.A, Vector3.left);
        AddMovement(KeyCode.LeftShift, Vector3.up);
        AddMovement(KeyCode.LeftControl, Vector3.down);
        Vector3 direction = transform.TransformVector(moveInput.normalized);

        if (Input.GetKey(KeyCode.E))
            return direction * (acceleration * accSprintMultiplier); // "Fast swim"
        return direction * acceleration; // "normal swim"
    }
}






