using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceLock : MonoBehaviourPunCallbacks    
{

    [SerializeField] private LockedDoorTrigger lockedDoorTrigger;
    [SerializeField] private PhotonView PV;
    [SerializeField] private GameObject keyLock;
    [SerializeField] private Item keyItem;


    public void HandleAction(Transform transform)
    {
        CheckIfKeyIsThere(transform);                
    }

    [PunRPC]
    private void RPCDestroyLock()
    {
        Object.Destroy(keyLock);
    }

    [PunRPC]
    private void UnlockedFences()
    {
        lockedDoorTrigger.CodeSolved();
    }

    private void CheckIfKeyIsThere(Transform transform)
    {
        Item currentlyEquippedItem = transform.GetComponentInChildren<EquipmentManager>().CurrentlyEquipedItem;

        if (currentlyEquippedItem != null)
        {
            if (currentlyEquippedItem.Data.ItemName == keyItem.Data.ItemName)
            {
                UnlockFence();
                transform.GetComponentInChildren<PlayerInventory>().RemoveItem(currentlyEquippedItem);
            }
        }
           
    }

    private void UnlockFence()
    {
        PV.RPC("UnlockedFences", RpcTarget.Others);
        UnlockedFences();

        PV.RPC("RPCDestroyLock", RpcTarget.Others);
        RPCDestroyLock();
    }
}
