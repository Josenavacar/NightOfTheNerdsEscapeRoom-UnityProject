using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviourPunCallbacks
{
    private PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }
}
