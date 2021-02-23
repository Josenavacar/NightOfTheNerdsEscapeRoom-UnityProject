using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaper : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView PV;
    [SerializeField] private NewsPaperAnimator newsPaperAnimator;

    private bool openedNewsPaper = false;

    public void OpenNewsPaper()
    {
        PV.RPC("RPCHandleNewsPaperOpen", RpcTarget.Others, true);
        RPCHandleNewsPaperOpen(true);
    }

    [PunRPC]
    private void RPCHandleNewsPaperOpen(bool opened)
    {
        openedNewsPaper = opened;
        newsPaperAnimator.NewsPaperOpen();
    }
}
