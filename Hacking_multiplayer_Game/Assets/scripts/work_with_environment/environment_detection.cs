using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class environment_detection : MonoBehaviour
{
    public Transform leftfoottarget;
    public Transform leftkee;
    public float raydistance;
    public LayerMask layermask;

    private void Update()
    {
        leftleg();
    }

    void leftleg()
    {
        RaycastHit hit;

        Vector3 raydirection = -transform.up; // Use -transform.up for the ray direction

        if (Physics.Raycast(leftkee.position, raydirection, out hit, raydistance, layermask))
        {
            float lerpfect = 0.01f;
            leftfoottarget.position = Vector3.Lerp(leftfoottarget.position, hit.point, lerpfect);

            Debug.DrawRay(leftkee.position, raydirection * hit.distance, Color.red);
        }
    }
}
