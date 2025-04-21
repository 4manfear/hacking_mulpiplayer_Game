using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;


public class pistol_script : MonoBehaviour
{
    public int bullet_count;
    public Pistol_reload PR;

    public Player_movement pm;

    public GameObject bullet;
    public Transform muzzel;
    public float bulletSpeed;

    public Animator anim;
    public bool cankill;


    public bool aimistrue;

    public bool oneonley;
    public bool hasFired = false;


    float time_gap_between_bullet;
    public bool shoted;

    float number_of_mag;
    float number_of_bullet;

    public TwoBoneIKConstraint left_hand_bon_container;
    public TwoBoneIKConstraint Right_hand_bon_container;
    public MultiAimConstraint Aim;

    

    public LayerMask layer;
    RaycastHit hit;
    private void Update()
    {
        
        
            if (PR.rrrr == true)
            {
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetBool("aim_pistol", false);
                anim.SetBool("fire_from_pistol", false);
                aimistrue = false;
                oneonley = false;
            }

            taking_aim();

            if (bullet_count != 0)
            {
                fire_Pistol_bullet();
            }



            if (aimistrue == true)
            {
                Aim.weight = 0.867f;
                left_hand_bon_container.weight = 1;
                Right_hand_bon_container.weight = 1;
            }
            if (aimistrue == false)
            {
                Aim.weight = 0;
                left_hand_bon_container.weight = 0;
                Right_hand_bon_container.weight = 0;
            }

        


        //if (shoted == true)
        //{
        //    StartCoroutine(cant_shoot());
        //}


    }

    //IEnumerator cant_shoot()
    //{
    //    yield return new WaitForSeconds(2f);
    //    shoted = false;
    //}

    void taking_aim()
    {
        if (Gamepad.current.leftTrigger.isPressed)
        {
            anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
            anim.SetBool("aim_pistol", true);
            aimistrue = true;


        }
        if (Gamepad.current.leftTrigger.wasReleasedThisFrame)
        {
            anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
            anim.SetBool("aim_pistol", false);
            aimistrue = false;
        }
    }
    void fire_Pistol_bullet()
    {
        if (aimistrue == true)
        {
            if (shoted == false)


            {
                if (Gamepad.current.rightTrigger.isPressed && oneonley == false)
                {
                    shoted = true;

                    bullet_count--;

                    anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
                    anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
                    anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                    anim.SetBool("fire_from_pistol", true);
                    //anim.SetBool("aim_pistol", false);
                    
                    Shooting();
                    oneonley = true;

                    
                }

            }


            if (Gamepad.current.rightTrigger.wasReleasedThisFrame)
            {
                shoted = false;
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetBool("fire_from_pistol", false);

                oneonley = false;
            }
            if (aimistrue == false)
            {
                anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
                anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
                anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
                anim.SetBool("fire_from_pistol", false);
            }
        }
            
        
    }

    //void Pistol_bullet_fire()
    //{
    //    GameObject newbullet = Instantiate(bullet, muzzel.position, Quaternion.identity);

    //    //calculating direction 
    //    Vector3 raycastdirection = playerCamera.forward;

    //    RaycastHit rayhitting;
    //    if (Physics.Raycast(playerCamera.position, playerCamera.forward, out rayhitting, Mathf.Infinity))
    //    {
    //        // setting bullet direction towards raycast hit point
    //        raycastdirection = rayhitting.point - muzzel.position;
    //    }
    //    // Give the bullet an initial velocity in the direction of the raycast
    //    Rigidbody bulletRb = newbullet.GetComponent<Rigidbody>();
    //    bulletRb.velocity = raycastdirection.normalized * bulletSpeed;




    //}

    void Shooting()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (aimistrue && Gamepad.current.rightTrigger.isPressed)
        {
            Vector3 raycastdirection = ray.direction * bulletSpeed;

            GameObject newbullet = Instantiate(bullet, muzzel.position, Quaternion.identity);
            Rigidbody bulletRb = newbullet.GetComponent<Rigidbody>();
            bulletRb.velocity = raycastdirection;
        }



       
    }


   
}
