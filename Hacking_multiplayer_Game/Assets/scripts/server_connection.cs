
using Photon.Pun;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class server_connection : MonoBehaviourPunCallbacks  // inherit from MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
            
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {

        SceneManager.LoadScene(1);
    }
}
