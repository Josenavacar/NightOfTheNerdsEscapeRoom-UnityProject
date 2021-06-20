using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class completePuzzle : MonoBehaviour
{
    [SerializeField] List<outputFunction> allFunctions;
    //public StartFTPPuzzle puzzleController;
    public bool puzzleComplete = false;
    public PhotonView photonview;
    void Start()
    {
        //allFunctions.AddRange(FindObjectsOfType<outputFunction>());
        //puzzleController = FindObjectOfType<StartFTPPuzzle>();
        //Debug.Log($"{GetComponentInChildren<outputFunction>().name}");
        allFunctions.AddRange(GetComponentsInChildren<outputFunction>());
        photonview = GetComponent<PhotonView>();
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
                    photonview.RPC("SyncronizationSetComplete", RpcTarget.All, puzzleComplete);
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
                photonview.RPC("SyncronizationSetComplete", RpcTarget.All, puzzleComplete);
                Debug.Log("Complete puzzle script set outputfunction.puzzlecompleted to false");
            }
        }
    }
    [PunRPC]
    void SyncronizationSetComplete(bool one)
    {
        puzzleComplete = one;
    }
    
}
