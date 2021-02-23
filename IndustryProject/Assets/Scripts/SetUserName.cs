using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetUserName : MonoBehaviour
{
    #region SingleTon

    public static SetUserName instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    private Text textField;

    [HideInInspector]
    public string currentSavedUsername = "";

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<Text>();

        SetupUserName();
    }

    private void SetupUserName()
    {
        currentSavedUsername = PlayerPrefs.GetString("UserName");

        if (currentSavedUsername != "")
        {
            textField.text = currentSavedUsername;
        }
    }

    public void SetCurrentUserName()
    {
        currentSavedUsername = textField.text;
    }
}
