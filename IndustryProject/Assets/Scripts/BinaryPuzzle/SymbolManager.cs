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

    public string result;
    // Start is called before the first frame update
    void OnEnable()
    {
        ResetSymbols();
    }

    public void ResetSymbols()
    {
        int[] symbolsChosen = new int[3];

        //Assures symbols will be different.
        while((symbolsChosen[0] == symbolsChosen[1]) || (symbolsChosen[0] == symbolsChosen[2]) || (symbolsChosen[1] == symbolsChosen[2]))
        {
            symbolsChosen[0] = Random.Range(0, symbols.Count);
            symbolsChosen[1] = Random.Range(0, symbols.Count);
            symbolsChosen[2] = Random.Range(0, symbols.Count);
        }

        symbol1.sprite = symbols[symbolsChosen[0]].symbol;
        symbol2.sprite = symbols[symbolsChosen[1]].symbol;
        symbol3.sprite = symbols[symbolsChosen[2]].symbol;

        result = symbols[symbolsChosen[0]].number;
        result += symbols[symbolsChosen[1]].number;
        result += symbols[symbolsChosen[2]].number;
    }
}
