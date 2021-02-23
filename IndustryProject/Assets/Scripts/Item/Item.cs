using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Item_Data data;

    [SerializeField] private int currentAmountInInventory = 0;

    public Item_Data Data { get => data; private set => data = value; }
    public int CurrentAmountInInventory { get => currentAmountInInventory; set => currentAmountInInventory = value; }
}