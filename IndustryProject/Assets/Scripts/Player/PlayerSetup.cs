using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPunCallbacks
{

    public override void OnEnable()
    {
        base.OnEnable();
        PlayersInRoomManager.instance.AddPlayerToRoom(transform);
    }
}
