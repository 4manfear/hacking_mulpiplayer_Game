using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class drown_mechanic : MonoBehaviour
{
    public float moveSpeed ;
    public float rotationSpeed ;
    public float heightChangeSpeed;
    public Transform droneBody;

    private Vector2 moveing;
    private Vector2 look_around;

    private void Update()
    {
        MoveDrone();
        RotateDrone();
        AdjustHeight();
       // TiltDrone();
    }

    public void OnMovement(InputValue input)
    {
        moveing = input.Get<Vector2>();
    }

    public void OnLooking(InputValue input)
    {
        look_around = input.Get<Vector2>();
    }

    void MoveDrone()
    {
        Vector3 movement = new Vector3(moveing.x, 0f, moveing.y) * moveSpeed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        transform.position += movement;


       
    }

    void RotateDrone()
    {
        float rotation = look_around.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }

    void AdjustHeight()
    {
        float heightChange = 0f;

        // Check if a gamepad is connected before accessing its input
        if (Gamepad.current != null)
        {
            // Adjust height based on trigger input
            heightChange += Gamepad.current.leftTrigger.isPressed ? heightChangeSpeed * Time.deltaTime : 0f;
            heightChange -= Gamepad.current.rightTrigger.isPressed ? heightChangeSpeed * Time.deltaTime : 0f;
        }

        // Set the new position directly based on height change
        Vector3 newPosition = transform.position + Vector3.up * heightChange;
        transform.position = newPosition;
    }

    //void TiltDrone()
    //{
    //    if (moveing.magnitude > 0.1f)
    //    {
    //        // Calculate the angle of tilt based on movement direction(Mathf.Atan2 is used to find the angle between the positive X-axis and a point given its X and Y coordinates. It's especially useful for determining the direction in which something is moving or the angle at which something is pointing.)


    //        float tiltAngle = Mathf.Atan2(moveing.x, moveing.y) * Mathf.Rad2Deg;

    //        // Apply the tilt to the drone body
    //        droneBody.localRotation = Quaternion.Euler(0f, tiltAngle, 0f);
    //    }
    //    else
    //    {
    //        // Reset the tilt when there is no movement
    //        droneBody.localRotation = Quaternion.identity;
    //    }
    //}


}
