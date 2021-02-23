using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionManager : MonoBehaviour
{
    private ItemSlotManager itemSlotsManager;
    private EquipmentManager equipmentManager;

    private int currentSelectedItemIndex;

    private void Start()
    {
        equipmentManager = GetComponent<EquipmentManager>();
        itemSlotsManager = GetComponent<ItemSlotManager>();

        UpdateSelection();
    }

    private void Update()
    {
        float scrollWheelAxis = InputReader.instance.MouseScrollWheel;

        if (scrollWheelAxis != 0)
        {
            if (scrollWheelAxis > 0)
            {
                SelectPrevious();
            }
            else if (scrollWheelAxis < 0)
            {             
                SelectNext();
            }
        }
    }

    private void SelectNext()
    {
        DeselectCurrent();

        currentSelectedItemIndex += 1;
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.ITEMSLOTS);

        UpdateSelection();
    }

    private void SelectPrevious()
    {
        DeselectCurrent();

        currentSelectedItemIndex -= 1;
        SoundObjectManager.instance.PlaySoundByAudioName(EnumAudioName.ITEMSLOTS);

        UpdateSelection();
    }

    private void UpdateSelection()
    {
        CheckForLoop();

        SelectCurrent();
    }

    private void CheckForLoop()
    {
        if (currentSelectedItemIndex > itemSlotsManager.ItemSlots.Count -1)
            currentSelectedItemIndex = 0;

        if (currentSelectedItemIndex < 0)
            currentSelectedItemIndex = itemSlotsManager.ItemSlots.Count - 1;
    }

    private void SelectCurrent()
    {
        itemSlotsManager.ItemSlots[currentSelectedItemIndex].Select();
        EquipCurrentItem();
    }

    private void DeselectCurrent()
    {
        UnEquipCurrentItem();
        itemSlotsManager.ItemSlots[currentSelectedItemIndex].DeSelect();
    }

    private void UnEquipCurrentItem()
    {
        equipmentManager.UnEquipItem(itemSlotsManager.ItemSlots[currentSelectedItemIndex]);
    }

    private void EquipCurrentItem()
    {
        equipmentManager.EquipItem(itemSlotsManager.ItemSlots[currentSelectedItemIndex]);
    }

    public int CurrentSelectedItemIndex { get => currentSelectedItemIndex; set => currentSelectedItemIndex = value; }
}
