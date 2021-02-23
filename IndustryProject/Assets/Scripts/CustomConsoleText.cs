using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomConsoleText : MonoBehaviour
{
    #region SingleTon

    public static CustomConsoleText instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [HideInInspector]
    public TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }
}
