using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomCreation : MonoBehaviourPunCallbacks
{
    public InputField creatRoom;
    public InputField joinRoom;
    



    public void CreateRoom()
    {
        // setting limits 
        RoomOptions roomOptions = new RoomOptions()
        {
            MaxPlayers = 2
        };

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
