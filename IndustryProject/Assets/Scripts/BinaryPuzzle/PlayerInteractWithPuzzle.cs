using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInteractWithPuzzle : MonoBehaviour
{
    //BINARY PUZZLE NEEDED OBJECTS
    #region Binary Puzzle Needed objects
    List<GameObject> triggerbox;
    private GameObject binaryPuzzle;
    private Scene currentScene;
    public GameObject playerCam;
    bool FTPPuzzleOn = false;
    GameObject FtpTrigger;
    GameObject FTPPuzzle;
    #endregion

    //FTP PUZZLE NEEDED OBJECTS
    #region FTP puzzle stuff
    public FTPController ftpcontroller;
    #endregion
    void Start()
    {
        //BINARY PUZZLE START NEDED OBJECTS / COMPONENTS
        #region Binary Puzzle
        //BinaryPuzzleStart
        binaryPuzzle = GameObject.FindGameObjectWithTag("BinaryPuzzle");
        if(binaryPuzzle != null)
        {
            binaryPuzzle.SetActive(false);
        }

        triggerbox = new List<GameObject>(GameObject.FindGameObjectsWithTag("BinaryPuzzleTrigger"));



        #endregion
        //FTP PUZZLE START NEEDED OBJECTS / COMPONENTS
        #region ftp puzzle
        ftpcontroller = FindObjectOfType<FTPController>();

        if(ftpcontroller != null)
        {
            ftpcontroller.disableAllFTPOnStart();
        }
        #endregion
    }
    void Update()
    {
        //BINARY CHECKS FOR BINARY pUZZLE REMOVE SCENE CHECK UPON MERGING OF ALL SCENES
        #region Binary Puzzle interact
        if (Input.GetKeyDown(KeyCode.F))
            {
                //CHECKING IF TRIGGERBOX IS NOT NULL SO IT DOESN'T BREAK IN DIFFERENT SCENES *FOR TESTING PURPOSES*
                if (triggerbox != null)
                {
                    foreach(GameObject pc in triggerbox)
                    {
                        if(Vector3.Distance(pc.transform.position, this.gameObject.transform.position) < 3)
                        {
                            binaryPuzzle.SetActive(true);
                            gameObject.GetComponent<MovementPlayer>().enabled = false;
                            playerCam.GetComponent<LookMouse>().enabled = false; 
                        }
                    }
                }
            }
            if(binaryPuzzle != null && !FTPPuzzleOn)
            {
                if(!binaryPuzzle.activeSelf)
                {
                    gameObject.GetComponent<MovementPlayer>().enabled = true;
                    playerCam.GetComponent<LookMouse>().enabled = true;
                }
            }
        #endregion

        // FTP CHECKS FOR FTP PUZZLE REMOVE SCENE CHECK UPON MERGING OF ALL SCENES
        #region ftp puzzle interact
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(ftpcontroller.FtpTrigger1 != null)
            {
                if (Vector3.Distance(ftpcontroller.FtpTrigger1.transform.position, this.gameObject.transform.position) < 3)
                {
                    if (!ftpcontroller.CheckNearPuzzle1())
                    {
                        DisableMovement();
                    }
                }
                if (Vector3.Distance(ftpcontroller.FtpTrigger2.transform.position, this.gameObject.transform.position) < 3)
                {
                    if (!ftpcontroller.CheckNearPuzzle2())
                    {
                        DisableMovement();
                    }
                }
            }
        }
    }
    private void DisableMovement()
    {
        gameObject.GetComponent<MovementPlayer>().enabled = false;
        playerCam.GetComponent<LookMouse>().enabled = false;
        FTPPuzzleOn = true;
    }
    public void RestartAfterPuzzle()
    {
        gameObject.GetComponent<MovementPlayer>().enabled = true;
        playerCam.GetComponent<LookMouse>().enabled = true;
        FTPPuzzleOn = false;
    }
    #endregion
}
