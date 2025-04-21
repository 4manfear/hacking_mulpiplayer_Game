using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float runSpeed;
    public Camera cmmain;
    public float x;
    public float y;
    public CharacterController cc;

     

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    private void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector3 forward = cmmain.transform.forward;
        Vector3 right = cmmain.transform.right;
        // Ensure the vectors are normalized
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();


        Vector3 movedir = (right * x  + forward * y).normalized;

        if (movedir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movedir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        cc.Move(movedir .normalized *speed * Time.deltaTime) ;


    }
}
