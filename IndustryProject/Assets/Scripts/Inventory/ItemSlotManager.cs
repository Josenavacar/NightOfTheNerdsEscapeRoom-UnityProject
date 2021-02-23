using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSlotManager : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>();

    private PlayerInventory playerInventory;
    private EquipmentManager equipmentManager;
    private SelectionManager selectionManager;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        equipmentManager = GetComponent<EquipmentManager>();
        selectionManager = GetComponent<SelectionManager>();
    }


    public void SyncronizeInventoryWithSlots()
    {
        ClearItemsFromSlots();
        FillSlots();
        RefreshEquipment();
    }

    private void RefreshEquipment()
    {
        equipmentManager.UnEquipItem(itemSlots[selectionManager.CurrentSelectedItemIndex]);
        equipmentManager.EquipItem(itemSlots[selectionManager.CurrentSelectedItemIndex]);
    }

    private void FillSlots()
    {
        //foreach item we check for an available slot
        foreach (Item item in playerInventory.ItemsInInventory)
        {
            foreach (ItemSlot slot in itemSlots)
            {
                //If there is no item in slot we equip currentslot and go to the next slot
                if (!slot.ContainsItem())
                {
                   slot.SetItem(item);
                    break;
                }

                //If no item slot is free we catch it here 
            }
        }
    }

    private void ClearItemsFromSlots()
    {
        foreach (ItemSlot slot in itemSlots)
        {
            slot.RemoveItem();
        }
    }

    public List<ItemSlot> ItemSlots { get => itemSlots; }
}
