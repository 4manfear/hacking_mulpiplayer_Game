using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class find_the_object : MonoBehaviour
{
   

    public TwoBoneIKConstraint TB;
    public MultiRotationConstraint MR;

    public TwoBoneIKConstraint TB_L;
    public MultiRotationConstraint MR_L;

    public Transform body;

    public Transform right_Hand_target_point;
    public Transform left_Hand_target_point;

    public float dection_range;
    public float numRaycasts;

    public float L_dection_range;
    public float L_numRaycasts;

    public bool anyHit;

    float tam, timer;
    float TBweight, MBweight;

    private void Start()
    {

    }

    private void Update()
    {
        right_environment_intraction();
        left_environment_intraction();





        //if (object_entered_right == true)
        //{
        //    TB.weight = 1f;
        //    MR.weight = 1f;
        //}
        //if (object_entered_right == false)
        //{
        //    TB.weight = 0f;
        //    MR.weight = 0f;
        //}

    }

    void right_environment_intraction()
    {
        Vector3 forwardDirection = transform.forward;
        Vector3 rightDirection = transform.right;

        // Calculate the rotation from forward to right direction
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, rightDirection);

        anyHit = false; // Flag to track if any raycast has hit a collider

        for (int i = 0; i < numRaycasts; i++)
        {
            // Calculate the angle for this raycast
            float angle = i * (45f / numRaycasts);

            // Rotate the forward direction by the angle around the up axis
            Vector3 rayDirection = Quaternion.AngleAxis(angle, -Vector3.up) * forwardDirection;

            // Calculate the raycast direction in world space
            Vector3 raycastDirection = rotation * rayDirection;

            RaycastHit hit;
            if (Physics.Raycast(body.position, raycastDirection, out hit, dection_range))
            {
                if (hit.collider != null && !hit.collider.CompareTag("Hands"))
                {
                    anyHit = true; // Set flag to true if any raycast hits a collider

                    StartCoroutine(Smoothanimationofrighthand_goingup(1));
                    // Smoothly transition the position towards the hit point
                    float lerpFactor = 0.01f; // Adjust as needed for the desired speed of transition
                    left_Hand_target_point.position = Vector3.Lerp(left_Hand_target_point.position, hit.point, lerpFactor);

                    Debug.DrawRay(body.position, raycastDirection.normalized * hit.distance, Color.red);
                }
               
            }
            else
            {
                Debug.DrawRay(body.position, raycastDirection.normalized * dection_range, Color.green);
            }
        }

        if (!anyHit)
        {
            StartCoroutine(Smoothanimationofrighthand_goingup(0));
        }
    }

    IEnumerator Smoothanimationofrighthand_goingup(float targetweight)
    {
        tam = Time.deltaTime;
        TBweight = TB.weight;
        MBweight = MR.weight;

        if (tam != 1)
        {
            tam += Time.deltaTime;
            TB.weight = Mathf.Lerp(TBweight, targetweight, tam);
            MR.weight = Mathf.Lerp(TBweight, targetweight, tam);

        }
        if (tam == 1)
        {
            tam = 0;
        }
        yield return null;

    }

    void left_environment_intraction()
    {
        Vector3 forwardDirection = transform.forward;
        Vector3 lefttDirection = -transform.right;

        // Calculate the rotation from forward to right direction
        Quaternion L_rotation = Quaternion.FromToRotation(Vector3.forward, lefttDirection);

        anyHit = false; // Flag to track if any raycast has hit a collider

        for (int i = 0; i < L_numRaycasts; i++)
        {
            // Calculate the angle for this raycast
            float angle = i * (45f / L_numRaycasts);

            // Rotate the forward direction by the angle around the up axis
            Vector3 L_rayDirection = Quaternion.AngleAxis(angle, -Vector3.down) * forwardDirection;

            // Calculate the raycast direction in world space
            Vector3 L_raycastDirection = L_rotation * L_rayDirection;

            RaycastHit hit;
            if (Physics.Raycast(body.position, L_raycastDirection, out hit, L_dection_range))
            {
                if (hit.collider != null && !hit.collider.CompareTag("Hands"))
                {
                    anyHit = true; // Set flag to true if any raycast hits a collider

                    StartCoroutine(L_Smoothanimationofrighthand_goingup(1));
                    // Smoothly transition the position towards the hit point
                    float lerpFactor = 0.01f; // Adjust as needed for the desired speed of transition
                    right_Hand_target_point.position = Vector3.Lerp(right_Hand_target_point.position, hit.point, lerpFactor);

                    Debug.DrawRay(body.position, L_raycastDirection.normalized * hit.distance, Color.red);
                }
            }
            else
            {
                Debug.DrawRay(body.position, L_raycastDirection.normalized * L_dection_range, Color.green);
            }
        }

        if (!anyHit)
        {
            StartCoroutine(L_Smoothanimationofrighthand_goingup(0));
        }
    }

    IEnumerator L_Smoothanimationofrighthand_goingup(float L_targetweight)
    {
        tam = Time.deltaTime;
        TBweight = TB_L.weight;
        MBweight = MR_L.weight;

        if (tam != 1)
        {
            tam += Time.deltaTime;
            TB_L.weight = Mathf.Lerp(TBweight, L_targetweight, tam);
            MR_L.weight = Mathf.Lerp(TBweight, L_targetweight, tam);

        }
        if (tam == 1)
        {
            tam = 0;
        }
        yield return null;

    }
}
