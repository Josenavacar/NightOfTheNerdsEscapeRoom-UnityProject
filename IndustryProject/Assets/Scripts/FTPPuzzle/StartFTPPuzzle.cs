using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFTPPuzzle : MonoBehaviour
{
    public completePuzzle puzzleCompleteCheck;

    private void Start()
    {
        puzzleCompleteCheck = GetComponent<completePuzzle>();
    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            //thisCanvas.enabled = false;
            //paused = true;
        }
    }
    //public void checkIfStartFTP()
    //{
    //    if (!puzzleCompleteCheck.puzzleComplete)
    //    {
    //        this.gameObject.SetActive(true);
    //    }
    //}
    //public void checkIfStop()
    //{
    //    if (puzzleCompleteCheck.puzzleComplete)
    //    {
    //        this.gameObject.SetActive(false);
    //    }
    //}


}
