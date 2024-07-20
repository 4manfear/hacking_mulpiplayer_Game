using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_direction : MonoBehaviour
{
    Camera cameramain;

    public Vector3 direction;

    private void Update()
    {
        if (cameramain != null)
        {
            direction = cameramain.transform.forward;
        }
    }

}
