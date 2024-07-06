using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomCreation : MonoBehaviourPunCallbacks
{
    public InputField creatRoom;
    public InputField joinRoom;
    

    public void CreateRoom()
    {
        
            PhotonNetwork.CreateRoom(creatRoom.text);
        
    }    

    public void JoinRoom()
    {
        
            PhotonNetwork.JoinRoom(joinRoom.text);
        
    }


    public override void OnJoinedRoom()
    {

        PhotonNetwork.LoadLevel("level");
    }
}
