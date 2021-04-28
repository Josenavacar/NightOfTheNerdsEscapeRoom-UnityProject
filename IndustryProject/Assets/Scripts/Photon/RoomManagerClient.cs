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

    public TextMeshProUGUI errorText;

    //join
    public void JoinRoom()
    {
        errorText.gameObject.SetActive(false);
        string roomCode = RoomCodeText.instance.Text;

        SetUserName.instance.SetCurrentUserName();

        PlayerPrefs.SetString("UserName", SetUserName.instance.currentSavedUsername);

        Debug.Log("Join room with id: " + RoomCodeText.instance.Text);
        if(PhotonNetwork.JoinRoom(RoomCodeText.instance.Text) == false) {
            errorText.gameObject.SetActive(true);
        }
    }
}
