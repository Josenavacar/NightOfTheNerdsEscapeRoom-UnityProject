using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "New Item")]
public class Item_Data : ScriptableObject
{
    [Header("Default")]
    [SerializeField] private string itemName = "";

    [SerializeField] private string description = "";

    [SerializeField] private Sprite itemIcon;

    [Header("ItemProperties")]
    [SerializeField] private bool opensDoors = false;
    [SerializeField] private int keyValue = 0000;

    public string ItemName { get => itemName; private set => itemName = value; }
    public string Description { get => description; private set => description = value; }
    public Sprite ItemIcon { get => itemIcon; private set => itemIcon = value; }
    public int KeyValue { get => keyValue; private set => keyValue = value; }
    public bool OpensDoors { get => opensDoors; private set => opensDoors = value; }

}