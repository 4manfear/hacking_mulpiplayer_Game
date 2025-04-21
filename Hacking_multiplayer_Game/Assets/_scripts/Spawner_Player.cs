using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Player : MonoBehaviour
{
    public Transform[] _spawner;

    public GameObject PlayerPre;
    private void Start()
    {
        int CurrSpawnpoint = Random.Range(0, _spawner.Length);

        PhotonNetwork.Instantiate(PlayerPre.name, _spawner[CurrSpawnpoint].position, Quaternion.identity);
    }

}
