using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTPController : MonoBehaviour
{
    GameObject[] allFTPPuzzles;
    public GameObject FtpTrigger1;
    public GameObject FtpTrigger2;

    public StartFTPPuzzle start1;
    public StartFTPPuzzle start2;


    private void Start()
    {
        allFTPPuzzles = GameObject.FindGameObjectsWithTag("FTPPuzzle");
        FtpTrigger1 = GameObject.Find("FTPtrigger1");
        FtpTrigger2 = GameObject.Find("FTPtrigger2");
        start1 = allFTPPuzzles[0].GetComponent<StartFTPPuzzle>();
        start2 = allFTPPuzzles[1].GetComponent<StartFTPPuzzle>();
    }
    public void disableAllFTPOnStart()
    {
        foreach (var item in allFTPPuzzles)
        {
            item.SetActive(false);
        }
    }
    public bool CheckNearPuzzle1()
    {
        start1.checkIfStartFTP();
        return start1.puzzleCompleteCheck.puzzleComplete;
    }
    public bool CheckNearPuzzle2()
    {
        start2.checkIfStartFTP();
        return start2.puzzleCompleteCheck.puzzleComplete;

    }
}
