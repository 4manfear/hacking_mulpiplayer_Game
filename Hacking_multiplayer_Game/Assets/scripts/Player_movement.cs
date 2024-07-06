using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using Photon.Pun;

public class Player_movement : MonoBehaviourPunCallbacks
{
    public TwoBoneIKConstraint left_hand_bon_container;
    public TwoBoneIKConstraint Right_hand_bon_container;
    public MultiAimConstraint Aim;
    public TwoBoneIKConstraint right_hand_miile;

    public PhotonView view;
    public Camera mycam;


    public pistol_script ps;
    public GameObject additionalGameobject;


    Animator anim;

    public float walkspeed;

    public float speed ;
    public float lookSpeed ; 

    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Transform playerCamera;
    public bool isLooking;
    public  Transform R_arm;
    public Transform L_arm;
    public Transform head;

    public bool Shoot;
    public Transform debugPos;

    //public GameObject bullet;
    //public Transform muzzel;
    //public float bulletSpeed;

    public bool canrun;
    public float runspeed;

    public bool cankill;


    public bool aimistrue;

    private void Start()
    {

        if(!view.IsMine)
        {
           mycam.enabled = false;
        }

        Aim.weight = 0;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main.transform;

        left_hand_bon_container.weight = 0;
        Right_hand_bon_container.weight = 0;
        right_hand_miile.weight = 0f;

        // Ensure the additionalObject is a child of the player
        additionalGameobject.transform.SetParent(transform);
        // Set its initial local position and rotation to zero
        additionalGameobject.transform.localPosition = Vector3.zero;
        additionalGameobject.transform.localRotation = Quaternion.identity;
    }

    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }

    public void OnLook(InputValue input)
    {
        lookInput = input.Get<Vector2>();

    }

    

    private void FixedUpdate()
    {
        if(view.IsMine)
        {
            MovePlayer();
            RotatePlayer();
        }
        

    }

    private void MovePlayer()
    {
        // Get the forward direction of the camera without any vertical component
        Vector3 cameraForward = Vector3.Scale(playerCamera.forward, new Vector3(1, 0, 1)).normalized;

        // Calculate the movement direction based on the camera's forward direction
        Vector3 moveDirection = (cameraForward * moveInput.y + playerCamera.right * moveInput.x).normalized;

        // Move the player in the calculated direction
        rb.velocity = moveDirection * speed;
    }

    private void RotatePlayer()
    {
        // Calculate the rotation input
        Vector2 rotationInput = new Vector2(lookInput.x, lookInput.y) * lookSpeed * Time.fixedDeltaTime;

        // Rotate the player around the Y-axis
        transform.Rotate(Vector3.up, rotationInput.x);

        // Calculate the new rotation angle for the camera around the X-axis
         float newRotationX = playerCamera.localRotation.eulerAngles.x - rotationInput.y;


        //newRotationX = Mathf.Clamp(newRotationX, -20f,120f);

        // Apply the new rotation to the camera
        playerCamera.localRotation = Quaternion.Euler(newRotationX, 0, 0);

        
            

    }

    void creainganimation()
    {
        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y)) // prioritize horizontal movement
        {
            if (moveInput.x > 0)
            {
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetFloat("movement_anim", 4f);
            }
            else if (moveInput.x < 0)
            {
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetFloat("movement_anim", 3f);
            }
            else
            {
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetFloat("movement_anim", 0f); // no horizontal movement
            }
        }
        else // prioritize vertical movement
        {
            if (moveInput.y > 0)
            {
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetFloat("movement_anim", 1f);
            }
            else if (moveInput.y < 0)
            {
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetFloat("movement_anim", 2f);
            }
            else
            {
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetFloat("movement_anim", 0f); // no vertical movement
            }
        }
    }
    private void Update()
    {
        if(view.IsMine)
        {
            // Rotate the additionalObject along with the player and camera
            additionalGameobject.transform.rotation = playerCamera.rotation;


            creainganimation();


            if (Gamepad.current.leftStickButton.isPressed)
            {
                canrun = true;
                speed = runspeed;
            }
            if (Gamepad.current.leftStickButton.wasReleasedThisFrame)
            {
                canrun = false;
                speed = walkspeed;
            }

            if (!canrun)
            {
                speed = walkspeed;
            }
        }
    }

       

   

}
