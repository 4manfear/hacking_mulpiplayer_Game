using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;

public class sphere_detection : MonoBehaviour
{
    public legs_real_life parent;
    [SerializeField] private LayerMask lm;

    public string layerName = "Ground";
    //private int layerIndex;

    private void Start()
    {
        lm = LayerMask.NameToLayer(layerName);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("ground check");
        if(other.gameObject.layer == lm)
        {
            parent.onground1 = true;
            Debug.Log("ground check 2");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == lm)
        {
            parent.onground1 = false;
        }
    }
}
