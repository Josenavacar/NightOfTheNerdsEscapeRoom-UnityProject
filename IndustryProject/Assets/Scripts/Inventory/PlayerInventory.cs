using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PhotonView PV;
    private ItemSlotManager itemSlotsManager;

    private List<Item> itemsInInventory = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        itemSlotsManager = GetComponent<ItemSlotManager>();
    }

    public void RemoveItem(Item itemToRemove)
    {
        if (itemsInInventory.Count != 0)
        {
            int indexToRemove = -1;

            foreach (Item item in itemsInInventory)
            {
                indexToRemove += 1;

                if (item.Data.ItemName == itemToRemove.Data.ItemName)
                {
                    item.CurrentAmountInInventory -= 1;

                    if (item.CurrentAmountInInventory > 1)
                        return;
                }
            }

            itemsInInventory.RemoveAt(indexToRemove);

            itemSlotsManager.SyncronizeInventoryWithSlots();
        }
    }

    public void AddItem(Item itemToAdd)
    {
        itemToAdd.CurrentAmountInInventory += 1;

        foreach (Item item in itemsInInventory)
        {
            if (item.Data.ItemName == itemToAdd.Data.ItemName)
            {
                return;
            }
        }

        itemsInInventory.Add(itemToAdd);

        itemSlotsManager.SyncronizeInventoryWithSlots();
    }

    public List<Item> ItemsInInventory { get => itemsInInventory; }
}
