using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomManagerMasterClient : MonoBehaviourPunCallbacks
{
    [SerializeField] private int lobbySceneNumber;

    private int roomID = 0;

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            //Set room id
            SetRandomRoomID();
            Debug.Log("try to create a room with number: " + RoomCodeText.instance.Text);

            RoomOptions ro = new RoomOptions();

            ro.MaxPlayers = 4;

            PhotonNetwork.CreateRoom(RoomCodeText.instance.Text, ro);
        }
    }

    public override void OnJoinedRoom()
    {
        SetUserName.instance.SetCurrentUserName();

        PlayerPrefs.SetString("UserName", SetUserName.instance.currentSavedUsername);

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(lobbySceneNumber);
        }
    } 

    public override void OnCreatedRoom()
    {
        Debug.Log("Created a room with number: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // CreateRoom();
    }

    private void SetRandomRoomID()
    {
        roomID = Random.Range(1000, 9999);
    }

    public int RoomID { get => roomID; private set => roomID = value; }
}