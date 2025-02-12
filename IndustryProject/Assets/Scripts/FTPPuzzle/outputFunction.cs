﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class outputFunction : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playerInput;
    int playerInput_m;
    public TMPro.TextMeshProUGUI randomNumber;
    int fixedNumber_m;
    public TMPro.TextMeshProUGUI symbol;
    public randomValues randomNumberScript;

    private TMPro.TextMeshProUGUI output;
    public int correctResult = 96;

    private int result;

    public bool puzzleCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        output = GetComponent<TMPro.TextMeshProUGUI>();
        randomNumberScript.output = correctResult;
    }

    // Update is called once per frame
    void Update()
    {
        playerInput_m = int.Parse(playerInput.text);
        fixedNumber_m = int.Parse(randomNumber.text);
        if (symbol.text == "-")
        {
            result = fixedNumber_m - playerInput_m;
        }
        if (symbol.text == "+")
        {
            result = playerInput_m + fixedNumber_m;
        }
        if (symbol.text == "*")
        {
            result = playerInput_m * fixedNumber_m;
        }
        if (symbol.text == "/")
        {
            result = playerInput_m / fixedNumber_m;
        }
        output.text = result.ToString();
        CorrectAnswer();
    }
    public void CorrectAnswer()
    {
        if (result == correctResult)
        {
            randomNumberScript.isCompleted = true;
            puzzleCompleted = true;
            //Debug.Log($"{puzzleCompleted} {this.GetInstanceID()}");
            output.color = Color.green;
        }
    }
    public void ResetPuzzle()
    {
        randomNumberScript.isCompleted = false;
        puzzleCompleted = false;
        playerInput.text = 0.ToString();
        output.color = Color.white;
        Debug.Log("outputFunction keep randoming set to true");
    }
   
}
