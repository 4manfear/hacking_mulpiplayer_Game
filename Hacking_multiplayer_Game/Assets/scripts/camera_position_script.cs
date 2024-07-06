using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_position_script : MonoBehaviour
{
  
    public Transform here, cam;

    // Update is called once per frame
    void Update()
    {
       
        cam.transform.position = here.position;
    }
}
