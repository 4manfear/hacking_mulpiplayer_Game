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
        //creating a personal server threw text and joining them.
            PhotonNetwork.CreateRoom(creatRoom.text);
        
    }    

    public void JoinRoom()
    {
        // joining the already created server threw text
            PhotonNetwork.JoinRoom(joinRoom.text);
        
    }


    public override void OnJoinedRoom()
    {

        PhotonNetwork.LoadLevel("level");
    }
}
