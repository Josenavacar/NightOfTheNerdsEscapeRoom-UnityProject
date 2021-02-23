using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text text;


    public void SetText(string value)
    {
        SetTextColor(value);
        text.text = value;
    }

    private void SetTextColor(string value)
    {
        if (value.Equals("FALSE"))
        {
            text.color = Color.red;
        }
        else if (value.Equals("CORRECT"))
        {
            text.color = Color.green;
            text.fontSize = 18;
        }
        else
        {
            text.color = Color.white;
        }
    }

}
