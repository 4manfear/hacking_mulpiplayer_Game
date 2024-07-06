using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class enemy_damage : MonoBehaviourPunCallbacks
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bullet") )
        {
            PhotonNetwork.Destroy(collision.gameObject);
        }
    }
}
