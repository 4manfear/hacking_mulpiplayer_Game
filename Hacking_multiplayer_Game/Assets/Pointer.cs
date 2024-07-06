using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    
    public Transform DebugTransform;
    public LayerMask layer;
    
    void Update()
    { 
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));

         if (Physics.Raycast(ray, out hit, Mathf.Infinity))
         {
          DebugTransform.position = hit.point;
         }
    }
}
