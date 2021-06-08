using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckResult : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<GameObject> lines;
    private SymbolManager resultHolder;
    public GameObject timerText;
    private bool won = false;
    private bool isVictoryEnabled = false;
    private SymbolManager symbolScript;
    private float timer;
    public int timerStart = 60;

    // Start is called before the first frame update
    void Start()
    {
        symbolScript = this.gameObject.GetComponent<SymbolManager>();
        resultHolder = gameObject.GetComponent<SymbolManager>();

        timer = timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        if(!won && isVictoryEnabled)
        {
            tickOnTimer();

            //check victory
            int counter = 0;
            char[] currentResult = resultHolder.result.ToCharArray();
            int i = 0;

            foreach(GameObject item in items)
            {
                char[] numToCheck = item.GetComponent<TMP_InputField>().text.ToCharArray();
               
                if(numToCheck[0] == currentResult[i])
                {
                    counter++;
                }
                
                i++;
            }

            if(counter == lines.Count)
            {
                Debug.Log("You won!");
                won = true;
                winGame();
            }

            counter = 0;
        }
        else
        {
            checkEnabled();
        }
        
    }

    void tickOnTimer()
    {
        //timer, to be tested
        /*
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <= 0)
        {
            resetPuzzle();
        }
        */

        int timerInt = (int) timer;
        timerText.GetComponent<TMP_Text>().text = timerInt.ToString();
    }

    void checkEnabled()
    {
        bool areLinesEnabled = true;
        foreach(GameObject line in lines)
        {
            if(!line.GetComponent<MovingNumbers>().lineEnabled)
            {
                areLinesEnabled = false;
            }
        }

        isVictoryEnabled = areLinesEnabled;
    }

    void resetPuzzle()
    {
        timer = timerStart;
        symbolScript.ResetSymbols();
    }

    void winGame()
    {
        string[] victory = new string[]{"C","O","M","P","L","E","T","E","!"};
        int i = 0;
        foreach(GameObject line in lines)
        {
            line.GetComponent<MovingNumbers>().finish();
        }

        foreach(GameObject item in items)
        {
            item.gameObject.GetComponent<TMP_InputField>().text = victory[i];
            item.gameObject.GetComponent<TMP_InputField>().textComponent.alpha = 1f;
            i++;
        }
    }
}
