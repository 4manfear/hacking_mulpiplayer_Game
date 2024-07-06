using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;
public class PhotonPing : MonoBehaviourPunCallbacks
{
    public Text PingText;
    void Update()
    {
        PingText.text = "Ping: " + PhotonNetwork.GetPing();
    }


    public void  ConnectToIndia()
    {
        PhotonNetwork.ConnectToRegion("in");
        SceneManager.LoadScene(1);
    }
}
