using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFTPPuzzle : MonoBehaviour
{
    public completePuzzle puzzleCompleteCheck;
    public PlayerInteractWithPuzzle PIWP;
    private Canvas thisCanvas;

    private void Start()
    {
        PIWP = FindObjectOfType<PlayerInteractWithPuzzle>();
        puzzleCompleteCheck = GetComponent<completePuzzle>();
    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
            //thisCanvas.enabled = false;
            //paused = true;
        }
        checkIfStop();
    }
    public void checkIfStartFTP()
    {
        if (!puzzleCompleteCheck.puzzleComplete)
        {
            this.gameObject.SetActive(true);
        }
    }
    public void checkIfStop()
    {
        if (puzzleCompleteCheck.puzzleComplete)
        {
            this.gameObject.SetActive(false);
            PIWP.RestartAfterPuzzle();
        }
    }


}
