
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class server_connection : MonoBehaviourPunCallbacks  // inherit from MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // using photon setting i am connection to the photon master server
        PhotonNetwork.ConnectUsingSettings();
        
            
    }

    public override void OnConnectedToMaster()
    {
        // just joining the default lobby after connecting the server
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        // loading seen 1
        SceneManager.LoadScene(1);
    }
}
