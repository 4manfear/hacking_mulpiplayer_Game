using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class animation_of_ybot : MonoBehaviour
{
    Animator anim;
    PlayerMovement pm;
    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(pm.y >0)
        {
            anim.SetFloat("movement", 1f);
        }
        if(pm.x == 0f && pm.y == 0f)
        {
            anim.SetFloat("movement", 0f);
        }
        if (pm.y < 0)
        {
            anim.SetFloat("movement", 2f);
        }
        if (pm.x < 0)
        {
            anim.SetFloat("movement", 3f);
        }
        if (pm.x > 0)
        {
            anim.SetFloat("movement", 4f);
        }

    }
}
