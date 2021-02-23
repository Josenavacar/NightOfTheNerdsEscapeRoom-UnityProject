using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScreen : MonoBehaviour
{
    #region SingleTon

    public static AnswerScreen instance;

    private void Awake()
    {
        if (instance != this || instance == null)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] TMPro.TMP_Text textField;

    public void UpdateText(string text)
    {
        textField.text = text;
    }
}
