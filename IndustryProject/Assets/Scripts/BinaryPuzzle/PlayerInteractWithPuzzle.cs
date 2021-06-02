using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInteractWithPuzzle : MonoBehaviour
{
    GameObject triggerbox;
    private GameObject binaryPuzzle;
    private Scene currentScene;

    public GameObject playerCam;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "BinaryPuzzle")
        {
            binaryPuzzle = GameObject.FindGameObjectWithTag("BinaryPuzzle");
            binaryPuzzle.SetActive(false);
            triggerbox = GameObject.Find("BinaryPuzzleTrigger");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene.name == "BinaryPuzzle")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(Vector3.Distance(triggerbox.transform.position, this.gameObject.transform.position) < 5)
                {
                    binaryPuzzle.SetActive(true);
                    gameObject.GetComponent<MovementPlayer>().enabled = false;
                    playerCam.GetComponent<LookMouse>().enabled = false;
                }
            }
            
            if(!binaryPuzzle.activeSelf)
            {
                gameObject.GetComponent<MovementPlayer>().enabled = true;
                playerCam.GetComponent<LookMouse>().enabled = true;
            }
        }
        
    }
}
