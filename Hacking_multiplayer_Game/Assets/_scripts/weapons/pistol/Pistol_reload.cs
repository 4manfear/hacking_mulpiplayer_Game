using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol_reload : MonoBehaviour
{
    public pistol_script ps_script;
    public Animator anim;

    public bool rrrr;

    private void Update()
    {
        if(ps_script.bullet_count == 0)
        {
            if (Gamepad.current.yButton.isPressed)
            {
                reloading();
            }
                
        }
    }
    void reloading()
    {


        anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
        anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
        anim.SetBool("Reloding", true);
            rrrr = true;
        
    }

    void reloding_false()
    {
        anim.SetLayerWeight(0, Mathf.Lerp(anim.GetLayerWeight(0), 0f, Time.deltaTime * 10f));
        anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
        anim.SetLayerWeight(2, Mathf.Lerp(anim.GetLayerWeight(2), 0f, Time.deltaTime * 10f));
        anim.SetBool("Reloding", false);
        rrrr=false;
    }
    void reloaded()
    {
        ps_script.bullet_count = 15;
    }
}
