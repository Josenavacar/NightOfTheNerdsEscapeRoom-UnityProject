using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTPController : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] float timerForTerminalsSync = 5f;

    public StartFTPPuzzle start1;
    public StartFTPPuzzle start2;
    public LockedDoorTrigger door;

    private bool FTPFullyComplete = false;

    private void Update()
    {
        if (!FTPFullyComplete)
        {
            if (start1.puzzleCompleteCheck.puzzleComplete)
            {
                if (timer < timerForTerminalsSync)
                {
                    timer += Time.deltaTime;
                    if (start2.puzzleCompleteCheck.puzzleComplete)
                    {
                        Debug.Log("both completed");
                        FTPFullyComplete = true;
                        door.CodeSolved();
                    }
                }
                else
                {
                    start1.puzzleCompleteCheck.resetPuzzle();
                    start2.puzzleCompleteCheck.resetPuzzle();
                }
            }
            if (start2.puzzleCompleteCheck.puzzleComplete)
            {
                if (timer < timerForTerminalsSync)
                {
                    timer += Time.deltaTime;
                    if (start1.puzzleCompleteCheck.puzzleComplete)
                    {
                        Debug.Log("both completed");
                        FTPFullyComplete = true;
                        door.CodeSolved();
                    }
                }
                else
                {
                    start1.puzzleCompleteCheck.resetPuzzle();
                    start2.puzzleCompleteCheck.resetPuzzle();
                }
            }
        }
    }
        
}
