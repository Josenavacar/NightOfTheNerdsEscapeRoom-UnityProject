using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : Interactable
{
    protected PhotonView PV;
    private Item item;

    protected void Start()
    {
        PV = GetComponent<PhotonView>();
        item = GetComponent<Item>();
    }

    public override void HandleAction(Transform transform)
    {
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.PICKUP_ITEM);
        AddItemToInventory(transform);
        RemoveItemFromScene();
    }

    private void AddItemToInventory(Transform transform)
    {
        transform.GetComponentInChildren<PlayerInventory>().AddItem(item);
        Debug.Log("Player picked up an item");
    }

    private void RemoveItemFromScene()
    {
        PV.RPC("RPCRemoveItemFromScene", RpcTarget.Others);
        RPCRemoveItemFromScene();
    }

    [PunRPC]
    private void RPCRemoveItemFromScene()
    {
        gameObject.SetActive(false);
    }
}
