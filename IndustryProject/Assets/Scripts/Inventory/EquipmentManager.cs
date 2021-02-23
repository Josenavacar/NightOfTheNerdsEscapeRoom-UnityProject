using UnityEngine;
using System.Collections;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private Transform itemPlacement;

    private Item currentlyEquipedItem;

    public void EquipItem(ItemSlot currentSelectedSlot)
    {
        if (currentSelectedSlot.ContainsItem())
        {
            currentlyEquipedItem = currentSelectedSlot.ItemInSlot;
            UpdateItemInHand();
        }
    }

    public void UnEquipItem(ItemSlot currentSelectedSlot)
    {
        if (currentSelectedSlot.ContainsItem())
        {
            currentlyEquipedItem = null;
            UpdateItemInHand();
        }
    }

    private void UpdateItemInHand()
    {
        //TODO: ShowItemInHand
    }

    public Item CurrentlyEquipedItem { get => currentlyEquipedItem; }
}
