using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomManagerClient : MonoBehaviourPunCallbacks
{
    //Client callbacks
    public override void OnJoinedRoom()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    //join
    public void JoinRoom()
    {
        string roomCode = RoomCodeText.instance.Text;

        SetUserName.instance.SetCurrentUserName();

        PlayerPrefs.SetString("UserName", SetUserName.instance.currentSavedUsername);

        Debug.Log("Join room with id: " + RoomCodeText.instance.Text);
        PhotonNetwork.JoinRoom(RoomCodeText.instance.Text);
    }
}
