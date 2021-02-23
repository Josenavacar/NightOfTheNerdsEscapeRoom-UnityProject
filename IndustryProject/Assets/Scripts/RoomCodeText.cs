using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomCodeText : MonoBehaviour
{
    #region SingleTon
    public static RoomCodeText instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    private Text roomCodeTextField;
    private string text;

    private void Start()
    {
        roomCodeTextField = GetComponent<Text>();
    }

    private void Update()
    {
        if (roomCodeTextField.text != text)
        {
            text = roomCodeTextField.text;
        }
    }

    public string Text { get => text; }
}
