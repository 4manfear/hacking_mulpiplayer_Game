using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class parcore : MonoBehaviour
{
    public Transform head;

    Animator anim;

    public Transform foot;
    public Vector3 direction;
    public float hight, frount;

    float objectHeight;

    public CapsuleCollider collidercapsule;
    float orignal_hight = 1.99f;
    float climbing_hight = 0.64f;

    public bool wallclimb, climbing;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        wall_climb();

        RaycastHit hit;

        direction = transform.up;

        Physics.Raycast(foot.position, direction, out hit, hight);

        Debug.DrawRay(foot.position, direction * hight, Color.blue);

        if(climbing == true)
        {
            collidercapsule.height = climbing_hight;
        }
        if (climbing == false)
        {
            collidercapsule.height = orignal_hight;
        }
        
        if (wallclimb == true)
        {
            climbing_wall();
        }
    }

    void wall_climb()
    {
        RaycastHit top_head;

        if(Physics.Raycast(head.position, head.forward, out top_head, frount))
        {
           // wallclimb = true;
            if(top_head.collider)
            {
                float objectHeight = top_head.collider.bounds.min.x;
                Debug.Log("Object Height: " + objectHeight);
            }
            
            //if (objectHeight <= hight)
            //{
            //    wallclimb = true;
            //}
            //else
            //{
            //    wallclimb = false;
            //}

            
        }
        else
        {
            wallclimb = false;
        }

        Debug.DrawRay(head.position, head.forward * frount, Color.red);

    }

    void climbing_wall()
    {
        if (wallclimb == true)
        {
            if(Gamepad.current.aButton.isPressed)
            {
                anim.SetBool("climb", true);
                climbing = true;
            }
        }
       
        StartCoroutine(notclimb_wall());
            
        
    }

    IEnumerator notclimb_wall()
    {
        yield return new WaitForSeconds(2.5f);
        anim.SetBool("climb", false);
        climbing = false;
    }
}
