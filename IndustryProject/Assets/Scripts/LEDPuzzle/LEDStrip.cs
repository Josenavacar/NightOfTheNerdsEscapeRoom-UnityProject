using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDStrip : MonoBehaviour
{
    public GameObject button_sphere;
    public FTPTrigger FTPCompleteCheck = null;
    
    // Update is called once per frame
    void Update()
    {
        if (FTPCompleteCheck == null)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = button_sphere.GetComponent<MeshRenderer>().material.color;
        }
        else
        {
            if (FTPCompleteCheck.FTPPuzzle.GetComponent<completePuzzle>().puzzleComplete)
            {
                this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
