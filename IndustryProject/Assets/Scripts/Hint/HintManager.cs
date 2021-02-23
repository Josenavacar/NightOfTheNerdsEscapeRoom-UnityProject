using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    #region SingleTon
    public static HintManager instance;
    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;           
        }
    }
    #endregion

    [SerializeField] List<Hint> hints = new List<Hint>();


    public Hint getHintByHintNumber(int hintNumber)
    {
        foreach(Hint h in hints)
        {
            if (h != null)
            {
                if (h.HintNumber == hintNumber)
                {
                    return h;
                }
            }
        }
        return null;
    }

   

   
}
