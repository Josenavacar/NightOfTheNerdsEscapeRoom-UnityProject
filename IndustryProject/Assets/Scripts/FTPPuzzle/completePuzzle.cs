using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class completePuzzle : MonoBehaviour
{
    [SerializeField] List<outputFunction> allFunctions;
    //public StartFTPPuzzle puzzleController;
    public bool puzzleComplete;
    void Start()
    {
        //allFunctions.AddRange(FindObjectsOfType<outputFunction>());
        //Debug.Log($"{GetComponentInChildren<outputFunction>().name}");
        allFunctions.AddRange(GetComponentsInChildren<outputFunction>());
        //puzzleController = FindObjectOfType<StartFTPPuzzle>();
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
    
}
