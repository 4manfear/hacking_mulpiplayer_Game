using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class setting_switching_script : MonoBehaviour
{
    public GameObject quality;
    public GameObject Mainmenu;

    public void goingquality()
    {
        Mainmenu.SetActive(false);
        quality.SetActive(true);
    }
    public void goingmainmenu()
    {
        Mainmenu.SetActive(true);
        quality.SetActive(false);
    }
}
