using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class SymbolNumber
{
    public Sprite symbol;
    public string number;
}

public class SymbolManager : MonoBehaviour
{
    public Image symbol1, symbol2, symbol3;
    public List<SymbolNumber> symbols;
    private int[] symbolsChosen = new int[3];

    public string result;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < symbolsChosen.Length; i++)
        {
            symbolsChosen[i] = Random.Range(0, symbols.Count);
        }

        symbol1.sprite = symbols[symbolsChosen[0]].symbol;
        symbol2.sprite = symbols[symbolsChosen[1]].symbol;
        symbol3.sprite = symbols[symbolsChosen[2]].symbol;

        result = symbols[symbolsChosen[0]].number;
        result += symbols[symbolsChosen[1]].number;
        result += symbols[symbolsChosen[2]].number;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetSymbols()
    {
        for(int i = 0; i < symbolsChosen.Length; i++)
        {
            symbolsChosen[i] = Random.Range(0, symbols.Count);
        }

        symbol1.sprite = symbols[symbolsChosen[0]].symbol;
        symbol2.sprite = symbols[symbolsChosen[1]].symbol;
        symbol3.sprite = symbols[symbolsChosen[2]].symbol;

        result = symbols[symbolsChosen[0]].number;
        result += symbols[symbolsChosen[1]].number;
        result += symbols[symbolsChosen[2]].number;
    }
}
