using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewHint", menuName = "New Hint")]
public class Hint_Data : ScriptableObject
{
    [Header("Default")]
    [SerializeField] private string hintName = "";

    [SerializeField] private string description = "";
      

    [Header("HintProperties")]       
    [SerializeField] private List<EnumPlayerClasses> classes;

    public string HintName { get => hintName; private set => hintName = value; }
    public string Description { get => description;  set => description = value; }

    public List<EnumPlayerClasses> Classes { get => classes; private set => classes = value; }


}