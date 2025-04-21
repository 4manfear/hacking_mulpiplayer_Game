using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere_detection2 : MonoBehaviour
{
    public legs_real_life parent;
    [SerializeField] private LayerMask lm;
    public string layerName = "Ground";

    private void Start()
    {
        lm = LayerMask.NameToLayer(layerName);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log("ground check");
    //    if (other.gameObject.layer == lm)
    //    {
    //        parent.onground2 = true;
    //        Debug.Log("ground check");
    //    }

    //}


    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.layer == lm)
    //    {
    //        parent.onground2 = false;
    //    }
    //}
}
