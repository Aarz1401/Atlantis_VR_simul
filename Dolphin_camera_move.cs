using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class Dolphin_camera_move : MonoBehaviour
{
    public float acceleration = 15; // how fast you accelerate
    public float accSprintMultiplier = 4; // how much faster you go when "sprinting"
    public float dampingCoefficient = 5; // how quickly you break to a halt after you stop your input
    public bool focusOnEnable = true; // whether or not to focus and lock cursor immediately on enable

    Vector3 velocity; // current velocity

    static bool Focused
    {
        get => Cursor.lockState == CursorLockMode.Locked;
        set
        {
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !value; // Set cursor visibility based on focus
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
        if (Focused)
            UpdateInput();
        else if (Input.GetMouseButtonDown(0))
            Focused = true;

        velocity = Vector3.Lerp(velocity, Vector3.zero, dampingCoefficient * Time.deltaTime);
        transform.position += velocity * Time.deltaTime;
    }

    void UpdateInput()
    {
        velocity += GetAccelerationVector() * Time.deltaTime;

        // Allow free rotation
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        Quaternion rotation = transform.rotation;
        Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
        Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);

        // Restrict rotation to 4 directions (straight, behind, right, left)
        transform.rotation = GetRestrictedRotation(horiz * rotation * vert);

        if (Input.GetKeyDown(KeyCode.Escape))
            Focused = false;
    }

    Quaternion GetRestrictedRotation(Quaternion inputRotation)
    {
        // Get the current rotation angles
        Vector3 eulerRotation = inputRotation.eulerAngles;

        // Round the angles to the nearest 90 degrees
        eulerRotation.x = Mathf.Round(eulerRotation.x / 90) * 90;
        eulerRotation.y = Mathf.Round(eulerRotation.y / 90) * 90;
        eulerRotation.z = Mathf.Round(eulerRotation.z / 90) * 90;

        return Quaternion.Euler(eulerRotation);
    }

    Vector3 GetAccelerationVector()
    {
        Vector3 moveInput = Vector3.zero;

        void AddMovement(KeyCode key, Vector3 dir)
        {
            if (Input.GetKey(key))
                moveInput += dir;
        }

        // Allow movement in all directions (WASD keys)
        AddMovement(KeyCode.W, Vector3.forward);
        AddMovement(KeyCode.S, Vector3.back);
        AddMovement(KeyCode.D, Vector3.right);
        AddMovement(KeyCode.A, Vector3.left);
        AddMovement(KeyCode.LeftShift, Vector3.up);
        AddMovement(KeyCode.LeftControl, Vector3.down);

        Vector3 direction = transform.TransformDirection(moveInput.normalized);

        if (Input.GetKey(KeyCode.E))
            return direction * (acceleration * accSprintMultiplier); // "Fast swim"
        return direction * acceleration; // "normal swim"
    }
}

