using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class weapon_switch : MonoBehaviour
{
    public Player_movement pm;

    public GameObject pistol, miile;

    public find_the_object fto;

    [Header("scripts")]
    public pistol_script pistolsc;
    public miile stun;

    public bool smallgun, fist,stun_gun;

    float weaponswitcher;
    private void Start()
    {
        weaponswitcher = 0;
    }
    private void Update()
    {
        
        
            creatingloop();
            if (weaponswitcher >= 3f)
            {
                weaponswitcher = 0;
            }
            if (weaponswitcher <= -1f)
            {
                weaponswitcher = 1;
            }

            if (Gamepad.current.dpad.up.isPressed)
            {
                switchweaponpositive();
            }
            if (Gamepad.current.dpad.down.isPressed)
            {
                switchweaponnegative();
            }



            if (fist == true)
            {
                fto.enabled = true;
                pistol.SetActive(false);
                pistolsc.enabled = false;
                miile.SetActive(false);
                stun.enabled = false;

            }
            if (fist == false)
            {
                fto.enabled = false;
            }
            if (fist == false && smallgun == true)
            {
                pistol.SetActive(true);
                pistolsc.enabled = true;
                miile.SetActive(false);
                stun.enabled = false;
            }
            if (stun_gun == true && smallgun == false && fist == false)
            {
                miile.SetActive(true);
                stun.enabled = true;
                pistol.SetActive(false);
                pistolsc.enabled = false;
            }
        
       

        
    }
    void creatingloop()
    {
        if(weaponswitcher == 0)
        {
            fist = true;
            smallgun = false;
            stun_gun = false;
        }
        if(weaponswitcher == 1)
        {
            fist = false;
            smallgun = true;
            stun_gun = false;
        }
        if (weaponswitcher == 2)
        {
            fist= false;
            smallgun = false;
            stun_gun = true;
        }
    }
    void switchweaponpositive()
    {
        weaponswitcher++;
    }
    void switchweaponnegative()
    {
        weaponswitcher--;
    }

}
