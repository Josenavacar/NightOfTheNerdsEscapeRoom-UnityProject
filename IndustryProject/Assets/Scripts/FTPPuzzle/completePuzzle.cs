using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class completePuzzle : MonoBehaviour
{
    [SerializeField] List<outputFunction> allFunctions;
    [SerializeField] Image image;

    //public StartFTPPuzzle puzzleController;
    public bool puzzlecCompleted;
    void Start()
    {
        allFunctions.AddRange(FindObjectsOfType<outputFunction>());
        image = GetComponent<Image>();
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
                    puzzlecCompleted = true;
                    //image.color = Color.green;
                    //puzzleController.StopPuzzle();

                }
            }
            
        }
    }
    
}
