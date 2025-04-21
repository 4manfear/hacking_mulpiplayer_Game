using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Ik_groud_founder : MonoBehaviour
{
    
    [SerializeField] private Transform body;
    [SerializeField] private float footSpacing = 0.2f;
    [SerializeField] private LayerMask terrainlayer;
    [SerializeField] private Transform foot;
    

    [SerializeField] private float stepdistance = 0.5f;

    void Update()
    {
      

        // Cast a ray downward from the foot position
        Ray ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);

        // Check if the ray hits something on the terrain layer within a distance of 10 units
        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainlayer.value))
        {
            

            // Set the foot's position to the point where the ray hit the terrain
            
            foot.position = info.point;
        }
    }

    



}
