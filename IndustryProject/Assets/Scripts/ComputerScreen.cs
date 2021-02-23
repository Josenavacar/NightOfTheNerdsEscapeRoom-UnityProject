using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreen : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView PV;
    [SerializeField] private Canvas canvas;
    private bool power = false; 
    private bool pickup = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    public void InsertCable()
    {
        if (pickup)
        {
            PV.RPC("RPCHandleFixCable", RpcTarget.Others, true);
            RPCHandleFixCable(true);
        }
    }

    [PunRPC]
    private void RPCHandleFixCable(bool powered)
    {
        power = powered;
        canvas.enabled = true;
    }

    public void PickedUpWire()
    {
        pickup = true;
    }
}
