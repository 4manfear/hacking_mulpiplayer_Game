using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class quality_cuntroller : MonoBehaviour
{
    public Dropdown deopdown;

    public void cuntrolling_Quality(int val)
    {
        if (val == 0)
        {
            QualitySettings.SetQualityLevel(0);
        }
        if (val == 1)
        {
            QualitySettings.SetQualityLevel(1);
        }
        if (val == 2)
        {
            QualitySettings.SetQualityLevel(2);
        }
    }
}
