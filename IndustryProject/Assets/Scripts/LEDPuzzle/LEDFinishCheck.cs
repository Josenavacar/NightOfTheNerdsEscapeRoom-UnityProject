using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class LEDFinishCheck : MonoBehaviour
{
    public List<GameObject> buttons;
    public List<GameObject> lines;

    private bool linesEnabled = false;

    void Update()
    {
        countButtons();
    }

    void countButtons()
    {
        bool puzzleFinish = true;
        foreach(GameObject button in buttons)
        {
            if(!button.GetComponent<ButtonActive>().activated)
            {
                puzzleFinish = false;
            }
        }

        if(puzzleFinish && !linesEnabled)
        {
            completePuzzle();
            linesEnabled = true;
        }
    }

    void completePuzzle()
    {
        foreach(GameObject line in lines)
        {
            line.GetComponent<MovingNumbers>().lineEnabled = true;
        }
    }
}
