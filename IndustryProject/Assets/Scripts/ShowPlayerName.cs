using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPlayerName : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text textField;
    
    private PhotonView PV;

    private string playerName = "";

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();

        SetPlayerPref();
    }

    private void SetPlayerPref()
    {
        if (PV.IsMine)
        {
            playerName = PlayerPrefs.GetString("UserName");

            textField.text = "";

            PV.RPC("RPCsetPlayerName", RpcTarget.OthersBuffered, playerName);
        }
    }

    [PunRPC]
    private void RPCsetPlayerName(string playername)
    {
        playerName = playername;

        textField.text = playername;
    }
}
