using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private GameObject selectionObject;
    [SerializeField] private Image itemIcon;

    private Item itemInSlot;

    public void DeSelect()
    {
        selectionObject.SetActive(false);
    }

    public void Select()
    {
        selectionObject.SetActive(true);
    }

    public void SetItem(Item itemToSet)
    {
        itemInSlot = itemToSet;
        ShowIcon();
        //TODO: Show number on screen
    }

    public void RemoveItem()
    {
        HideIcon();
        itemInSlot = null;
    }

    public bool ContainsItem()
    {
        if (itemInSlot != null)
            return true;
        else
            return false;
    }

    private void ShowIcon()
    {
        if (ContainsItem())
        {
            itemIcon.sprite = itemInSlot.Data.ItemIcon;
        }
    }

    private void HideIcon()
    {
        if (ContainsItem())
        {
            itemIcon.sprite = null;
        }
    }

    public Item ItemInSlot { get => itemInSlot; }
}
