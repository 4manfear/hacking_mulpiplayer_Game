using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class legs_real_life : MonoBehaviour
{
    [Header("sphere position")]
    [SerializeField] private Transform Right_foot, Left_foot;

    private GameObject sphere1, sphere2;
    SphereCollider sc1, sc2;
    MeshRenderer mr1, mr2;

    [SerializeField] private TwoBoneIKConstraint right_foot, left_foot;

    public bool onground1, onground2;
    public LayerMask LM;

    float distance;

    private void Start()
    {
        createsphere();
    }

    private void Update()
    {
        CheckAndAdjustIKTarget(right_foot, Right_foot);
    }

    private void OnDrawGizmos()
    {
        if (Right_foot != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(Right_foot.position, 0.1f);
        }

        if (Left_foot != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(Left_foot.position, 0.1f);
        }
    }
    void createsphere()
    {

        sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sc1 = sphere1.GetComponent<SphereCollider>();
        sc1.radius = 0.1f;
        sc1.isTrigger = true;

        sc2 = sphere2.GetComponent<SphereCollider>();
        sc2.radius = 0.1f;
        sc2.isTrigger = true;



        mr1 = sphere1.GetComponent<MeshRenderer>();
        mr1.enabled = false;

        mr2 = sphere2.GetComponent<MeshRenderer>();
        mr2.enabled = false;

        sphere1.AddComponent<sphere_detection>().parent = this;
        sphere2.AddComponent<sphere_detection2>().parent = this;


    }
    private void FixedUpdate()
    {

        sphere1.transform.position = Right_foot.position;
        sphere2.transform.position = Left_foot.position;

        Debug.Log(distance);
        FindDistanceBetweenLegd();
    }

    void FindDistanceBetweenLegd()
    {
        distance = Vector3.Distance(Right_foot.position, Left_foot.position);
    }
    void CheckAndAdjustIKTarget(TwoBoneIKConstraint ikConstraint, Transform foot)
    {
        if (!onground1)
        {
            RaycastHit hit;
            if (Physics.Raycast(foot.position, Vector3.down, out hit, 1f,LM))
            {
                Transform ikTarget = ikConstraint.data.target;
                if (ikTarget != null)
                {
                    ikTarget.position = hit.point;
                    Debug.Log("IK Target adjusted to ground at position: " + hit.point);
                }
                else
                {
                    Debug.LogWarning("IK Target is not assigned in the constraint.");
                }
            }
        }
    }
}
