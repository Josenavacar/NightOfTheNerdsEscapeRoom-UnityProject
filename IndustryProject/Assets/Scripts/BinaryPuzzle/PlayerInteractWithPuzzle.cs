using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

public class PlayerInteractWithPuzzle : MonoBehaviour
{
    //BINARY PUZZLE NEEDED OBJECTS
    #region Binary Puzzle Needed objects
    List<GameObject> triggerbox;
    private GameObject binaryPuzzle;
    private Scene currentScene;
    public GameObject playerCam;

    #endregion

    //FTP PUZZLE NEEDED OBJECTS
    #region FTP puzzle stuff
    bool FTPPuzzleOn = false;
    List<GameObject> FtpTriggers;
    List<GameObject> FTPPuzzles;
    private GameObject thisOneActve = null;
    private PhotonView photon;
    #endregion
    void Start()
    {
        //BINARY PUZZLE START NEDED OBJECTS / COMPONENTS
        #region Binary Puzzle
        //BinaryPuzzleStart
        GameObject puzzleContainer = GameObject.FindGameObjectWithTag("PuzzleContainer");
        binaryPuzzle = puzzleContainer.GetComponent<PuzzleContainer>().binaryPuzzle;
        triggerbox = new List<GameObject>(GameObject.FindGameObjectsWithTag("BinaryPuzzleTrigger"));

        #endregion
        //FTP PUZZLE START NEEDED OBJECTS / COMPONENTS
        #region ftp puzzle
        FtpTriggers = new List<GameObject>(GameObject.FindGameObjectsWithTag("FTPPuzzleTrigger"));
        FTPPuzzles = new List<GameObject>(GameObject.FindGameObjectsWithTag("FTPPuzzle"));
        foreach (GameObject ftp in FTPPuzzles)
        {
            ftp.SetActive(false);
        }
        photon = transform.GetComponentInParent<PhotonView>();
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
            if (FtpTriggers!=null)
            {
                foreach (GameObject item in FtpTriggers)
                {
                    if ((Vector3.Distance(item.transform.position, this.gameObject.transform.position) < 3) && photon.IsMine)
                    {
                        thisOneActve = item.GetComponent<FTPTrigger>().FTPPuzzle;
                        item.GetComponent<FTPTrigger>().FTPPuzzle.SetActive(true);
                        //Debug.Log($"{item.transform.position} opening ftp puzzle");
                        gameObject.GetComponent<MovementPlayer>().enabled = false;
                        playerCam.GetComponent<LookMouse>().enabled = false;
                        FTPPuzzleOn = true;
                    }
                }
            }
        }
        if (FTPPuzzles != null)
        {
            foreach (GameObject item in FTPPuzzles)
            {
                if (item == thisOneActve && thisOneActve != null)
                {
                    //Debug.Log("item == this one active");
                    if (!item.activeSelf)
                    {
                        //Debug.Log("passed the activeself check");
                        gameObject.GetComponent<MovementPlayer>().enabled = true;
                        playerCam.GetComponent<LookMouse>().enabled = true;
                        FTPPuzzleOn = false;
                        thisOneActve = null;
                    }
                }
            }
        }
    }
    #endregion
}
