using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] private Hint_Data data;
    [SerializeField] private int hintNumber = 0 ;

    public Hint_Data Data { get => data;  set => data = value; }
    public int HintNumber { get => hintNumber; private set => hintNumber = value; }


}
