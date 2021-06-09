using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInteractWithPuzzle : MonoBehaviour
{
    //BINARY PUZZLE NEEDED OBJECTS
    #region Binary Puzzle Needed objects
    GameObject triggerbox;
    private GameObject binaryPuzzle;
    private Scene currentScene;
    public GameObject playerCam;
    GameObject FtpTrigger;
    GameObject FTPPuzzle;
    #endregion

    //FTP PUZZLE NEEDED OBJECTS
    #region FTP puzzle stuff
    //private GameObject FtpTrigger;
    //private GameObject FTPPuzzle;
    //private StartFTPPuzzle startFTP;
    public FTPController ftpcontroller;
    #endregion
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        //BINARY PUZZLE START NEDED OBJECTS / COMPONENTS
        #region Binary Puzzle
        //BinaryPuzzleStart
        binaryPuzzle = GameObject.FindGameObjectWithTag("BinaryPuzzle");
        if(binaryPuzzle != null)
        {
            binaryPuzzle.SetActive(false);
        }
        triggerbox = GameObject.FindGameObjectWithTag("BinaryPuzzleTrigger");
        #endregion
        //FTP PUZZLE START NEEDED OBJECTS / COMPONENTS
        #region ftp puzzle
        if (currentScene.name == "FTPPuzzle")
        {
            //FtpTrigger = GameObject.Find("FTPtrigger");
            //FTPPuzzle = GameObject.FindGameObjectWithTag("FTPPuzzle");
            //startFTP = FindObjectOfType<StartFTPPuzzle>();
            ftpcontroller = FindObjectOfType<FTPController>();
            ftpcontroller.disableAllFTPOnStart();
            //FTPPuzzle.SetActive(false);
        }
        #endregion
    }
    void Update()
    {
        //BINARY CHECKS FOR BINARY pUZZLE REMOVE SCENE CHECK UPON MERGING OF ALL SCENES
        #region Binary Puzzle interact
        //if(currentScene.name == "BinaryPuzzle")
        //{
        if (Input.GetKeyDown(KeyCode.F))
            {
                //CHECKING IF TRIGGERBOX IS NOT NULL SO IT DOESN'T BREAK IN DIFFERENT SCENES *FOR TESTING PURPOSES*
                if (triggerbox != null)
                {
                    if (Vector3.Distance(triggerbox.transform.position, this.gameObject.transform.position) < 5)
                    {
                        binaryPuzzle.SetActive(true);
                        gameObject.GetComponent<MovementPlayer>().enabled = false;
                        playerCam.GetComponent<LookMouse>().enabled = false;
                    }
                }
            }
            if(binaryPuzzle != null)
            {
                if(!binaryPuzzle.activeSelf)
                {
                    gameObject.GetComponent<MovementPlayer>().enabled = true;
                    playerCam.GetComponent<LookMouse>().enabled = true;
                }
            }
        //}
        #endregion

        // FTP CHECKS FOR FTP PUZZLE REMOVE SCENE CHECK UPON MERGING OF ALL SCENES
        #region ftp puzzle interact
        if (currentScene.name == "FTPPuzzle")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Vector3.Distance(ftpcontroller.FtpTrigger1.transform.position, this.gameObject.transform.position) < 5)
                {
                    if (!ftpcontroller.CheckNearPuzzle1())
                    {
                        DisableMovement();
                    }
                    //FTPPuzzle.SetActive(true);
                }
                if (Vector3.Distance(ftpcontroller.FtpTrigger2.transform.position, this.gameObject.transform.position) < 5)
                {
                    if (!ftpcontroller.CheckNearPuzzle2())
                    {
                        DisableMovement();
                    }
                    //FTPPuzzle.SetActive(true);
                }
            }
            //if (!FTPPuzzle.activeSelf)
            //{
            //    gameObject.GetComponent<MovementPlayer>().enabled = true;
            //    playerCam.GetComponent<LookMouse>().enabled = true;
            //}
        }
        
    }
    private void DisableMovement()
    {
        gameObject.GetComponent<MovementPlayer>().enabled = false;
        playerCam.GetComponent<LookMouse>().enabled = false;
    }
    public void RestartAfterPuzzle()
    {
        gameObject.GetComponent<MovementPlayer>().enabled = true;
        playerCam.GetComponent<LookMouse>().enabled = true;
    }
    #endregion
}
