using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Recorder.OutputPath;

public class ik_ground_newposition : MonoBehaviour
{
    // The Transform of the body part (e.g., the pelvis or hips)
    [SerializeField] private Transform body;

    // The spacing between the feet
    [SerializeField] private float footSpacing = 0.2f;

    // The layer mask for the terrain (ensure the terrain is on this layer)
    [SerializeField] private LayerMask terrainlayer;

    // The Transform of the foot (or feet)
    [SerializeField] private Transform foot;

    // The current position of the foot (initialize with foot's initial position)
    private Vector3 currentPosition;

    // The new position where the foot should move
    private Vector3 newPosition;

    // The minimum distance the foot should move to step
    [SerializeField] private float stepdistance = 0.5f;

    void Start()
    {
        // Initialize currentPosition with the foot's initial position
        currentPosition = foot.position;
        newPosition = foot.position;
    }

    void Update()
    {
        // Update the foot's position to the new calculated position
        foot.position = currentPosition;

        // Cast a ray downward from the foot position
        Ray ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);

        // Check if the ray hits something on the terrain layer within a distance of 10 units
        if (Physics.Raycast(ray, out RaycastHit info, 10, terrainlayer.value))
        {
            // Check if the distance between the current new position and the hit point is greater than stepdistance
            if (Vector3.Distance(newPosition, info.point) > stepdistance)
            {
                // Update the new position to the hit point
                newPosition = info.point;
            }

            // Set the foot's position to the new calculated position
            currentPosition = newPosition;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(newPosition, 0.5f);
    }
}
