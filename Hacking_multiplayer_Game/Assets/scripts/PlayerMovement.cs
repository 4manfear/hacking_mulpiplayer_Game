using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float runSpeed;

    public CharacterController cc;

     

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    private void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movedir = transform.right * x  + transform.forward * y;

        cc.Move(movedir .normalized *speed * Time.deltaTime) ;


    }
}
