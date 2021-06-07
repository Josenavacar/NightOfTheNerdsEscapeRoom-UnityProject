using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFTPPuzzle : MonoBehaviour
{
    [SerializeField] completePuzzle puzzleCompleteCheck;
    public PlayerInteractWithPuzzle PIWP;

    private void Start()
    {
        PIWP = FindObjectOfType<PlayerInteractWithPuzzle>();
    }
    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;

            if (puzzleCompleteCheck.puzzlecCompleted)
            {
                this.gameObject.SetActive(false);
            }
            PIWP.RestartAfterPuzzle();
            this.gameObject.SetActive(false);
            
        }
        
    }

}
