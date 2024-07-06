using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

public class miile : MonoBehaviour
{
    public Animator anim;
    public weapon_switch ws;

    public TwoBoneIKConstraint right_hand_miile;

    private void Start()
    {
        right_hand_miile.weight = 0f;
    }
    private void Update()
    {
        if (ws.stun_gun == true)
        {
            anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 1f, Time.deltaTime * 10f));
            anim.SetBool("holdin_stun_gun", true);
        }



        if(Gamepad.current.rightTrigger.isPressed)
        {
            anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 1f, Time.deltaTime * 10f));
            anim.SetBool("stungun", true);
            right_hand_miile.weight = 1f;
            StartCoroutine(bonessetorignal());

        }
        if(Gamepad.current.rightTrigger.wasReleasedThisFrame)
        {
            anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
            anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
            anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 1f, Time.deltaTime * 10f));
            anim.SetBool("stungun", false);

        }
    }
    IEnumerator bonessetorignal()
    {
        yield return new WaitForSeconds(2);
        right_hand_miile.weight = 0f;
    }

    
}
