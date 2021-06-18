using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FTPController : MonoBehaviour
{
    private float timer = 0f;
    [SerializeField] float timerForTerminalsSync = 5f;

    public StartFTPPuzzle start1;
    public StartFTPPuzzle start2;
    public LockedDoorTrigger door;
    public PhotonView photonview;

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
                        photonview.RPC("SyncronizationAllComplete", RpcTarget.All, FTPFullyComplete);
                        door.CodeSolved();
                    }
                }
                else
                {
                    //start1.puzzleCompleteCheck.resetPuzzle();
                    //start2.puzzleCompleteCheck.resetPuzzle();
                    resetPuzzlesAndTimer();
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
                        photonview.RPC("SyncronizationAllComplete", RpcTarget.All, FTPFullyComplete);
                        door.CodeSolved();
                    }
                }
                else
                {
                    //start1.puzzleCompleteCheck.resetPuzzle();
                    //start2.puzzleCompleteCheck.resetPuzzle();
                    resetPuzzlesAndTimer();
                }
            }
        }
    }
    void resetPuzzlesAndTimer()
    {
        start1.puzzleCompleteCheck.resetPuzzle();
        start2.puzzleCompleteCheck.resetPuzzle();
        timer = 0f;
    }

    [PunRPC]
    void SyncronizationAllComplete(bool one)
    {
        FTPFullyComplete = one;
    }
        
}
