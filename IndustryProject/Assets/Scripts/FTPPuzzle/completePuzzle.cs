using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class completePuzzle : MonoBehaviour
{
    [SerializeField] List<outputFunction> allFunctions;
    //public StartFTPPuzzle puzzleController;
    public bool puzzleComplete = false;
    void Start()
    {
        //allFunctions.AddRange(FindObjectsOfType<outputFunction>());
        //puzzleController = FindObjectOfType<StartFTPPuzzle>();
        //Debug.Log($"{GetComponentInChildren<outputFunction>().name}");
        allFunctions.AddRange(GetComponentsInChildren<outputFunction>());
        
    }
    private void Update()
    {
        winPuzzle();
        
    }
    public void winPuzzle()
    {
        int counter = 0;
        foreach (var item in allFunctions)
        {
            if (item.puzzleCompleted)
            {
                counter++;
                if (counter == allFunctions.Count)
                {
                    Debug.Log("fnished puzzle");
                    puzzleComplete = true;
                    //puzzleController.StopPuzzle();
                }
            }
        }
    }
    public void resetPuzzle()
    {
        if (puzzleComplete)
        {
            foreach (var item in allFunctions)
            {
                item.ResetPuzzle();
                puzzleComplete = false;
                Debug.Log("Complete puzzle script set outputfunction.puzzlecompleted to false");
            }
        }
    }
    
}
