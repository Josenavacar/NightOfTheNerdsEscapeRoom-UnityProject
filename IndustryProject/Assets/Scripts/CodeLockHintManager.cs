using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLockHintManager : HintManager
{
    private string codeLockCode;
    

    public void HandleCode(string code)
    {
        codeLockCode = code;
        AddHintValue();
    }

    private void AddHintValue()
    {      
        int hintCounter = 0;
        foreach(char ch in codeLockCode.ToCharArray())
        {
            AddHintDescription(hintCounter, ch);        
            hintCounter++;
        }
    }  

    private void AddHintDescription(int hintCounter, char ch)
    {
       
        switch (hintCounter)
        {
            case 0:
                getHintByHintNumber(hintCounter).Data.Description = "string a = " +ch+";";
                break;
            case 1:
                getHintByHintNumber(hintCounter).Data.Description = "string b = " +ch+";";
                break;
            case 2:
                getHintByHintNumber(hintCounter).Data.Description = "string i = " + ch+";";
                break;
            case 3:
                getHintByHintNumber(hintCounter).Data.Description = "string x = " + ch+";";
                break;
            case 4:
                getHintByHintNumber(hintCounter).Data.Description = "string y = " + ch+";";
                break;
            case 5:
                getHintByHintNumber(hintCounter).Data.Description = "string z = " + ch+";";                
                break;
            
        }

    }


}
